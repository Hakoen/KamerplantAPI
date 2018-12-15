using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sessie_model;
using geregistreerdeklant_model;
using System.Timers;

namespace sessie_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sessieController : ControllerBase
    {
        private readonly kamerplantContext _context;
        

        public sessieController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/sessie
        [HttpGet]
        public List<sessie> Get()
        {
            closeSessions(null);
            return _context.sessie.ToList();
        }

        // GET api/sessie/5
        [HttpGet("{id}")]
        public bool Get(int id)
        {
            closeSessions(null);
            sessie Sessie = _context.sessie.Find(id);
            return Sessie.actief;
        }

        // POST api/values
        //Bij login post een sessie

        public class inlogObject 
        {
            public string email { get; set; }
            public string wachtwoord { get; set; }

        }

        [HttpPost]
        public sessie Post([FromBody] inlogObject login)
        {
            closeSessions(login);
            //Gebruiker identificeren
            geregistreerdeklant gebruiker = _context.geregistreerdeklant.SingleOrDefault(geregistreerdeklant => geregistreerdeklant.email == login.email.ToLower());

            if(_context.geregistreerdeklant.Contains(gebruiker))
            {
                try
                {
                    sessie newSessie = new sessie();
                    newSessie.geregistreerdeklantID = gebruiker.ID;
                    newSessie.intijd = DateTime.Now.ToString();
                    newSessie.actief = true;

                    _context.sessie.Add(newSessie);
                    _context.SaveChanges();
                    return newSessie;
                }
                catch
                {
                    sessie faalSessie = new sessie();
                    faalSessie.geregistreerdeklantID = 0;
                    faalSessie.intijd = DateTime.Now.ToString();
                    faalSessie.actief = false;
                    return faalSessie;
                }

            }
            else
            {
                sessie faalSessie = new sessie();
                faalSessie.geregistreerdeklantID = 0;
                faalSessie.intijd = DateTime.Now.ToString();
                faalSessie.actief = false;
                return faalSessie;
            }     
        }

        //PUT
        [HttpPut("{sessieID}")]
        public StatusCodeResult Put(int sessieID)
        {
            closeSessions(null);
            try
            {
                sessie huidigeSessie = _context.sessie.Find(sessieID);
                huidigeSessie.actief = false;
                huidigeSessie.uittijd = DateTime.Now.ToString();
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        public void closeSessions(inlogObject logObject)
        {
            int[] openSessies = (from sessie in _context.sessie
                                    where sessie.actief == true
                                    select sessie.ID).ToArray();

            for(int i = 0; i < openSessies.Length; i++)
            {
                
                if(logObject != null)
                {
                    //Checken of de inloggende gebruiker al en sessie open heeft
                    sessie _sessie = _context.sessie.Find(openSessies[i]);
                    geregistreerdeklant _gebruiker = _context.geregistreerdeklant.SingleOrDefault(geregistreerdeklant => geregistreerdeklant.email == logObject.email.ToLower());
                    if (_sessie.geregistreerdeklantID == _gebruiker.ID)
                    {
                        //Zeau ja: Sessie schlossen
                        closeSession(_sessie.ID);
                    }
                }
                else
                {
                    DateTime open = DateTime.Parse(_context.sessie.Find(openSessies[i]).intijd);
                    double tijd = (DateTime.Now - open).TotalSeconds;
                    if(tijd > 1800)
                    {
                        closeSession(openSessies[i]);
                    }
                }
            }   
        }
        public void closeSession(int sessieID)
        {
            sessie Sessie = _context.sessie.Find(sessieID);
            Sessie.actief = false;
            Sessie.uittijd = DateTime.Now.ToString();
            _context.SaveChanges();
            Console.WriteLine("Sessie: " + Sessie.ID + " is gesloten.");
        }
        
     }
}
