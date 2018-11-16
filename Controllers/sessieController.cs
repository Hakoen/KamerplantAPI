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
            return _context.sessie.ToList();
        }

        // GET api/sessie/5
        [HttpGet("{id}")]
        public bool Get(int id)
        {
            closeSessions();
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
        public int Post([FromBody] inlogObject login)
        {
            closeSessions();
            //Gebruiker identificeren
            geregistreerdeklant gebruiker = _context.geregistreerdeklant.SingleOrDefault(geregistreerdeklant => geregistreerdeklant.email == login.email.ToLower());
            bool authorized = (login.wachtwoord == gebruiker.wachtwoord) ? true : false;

            if(authorized)
            {
                try
                {
                    sessie newSessie = new sessie();
                    newSessie.geregistreerdeklantID = gebruiker.ID;
                    newSessie.intijd = DateTime.Now.ToString();
                    newSessie.actief = true;

                    _context.sessie.Add(newSessie);
                    _context.SaveChanges();
                    return newSessie.ID;
                }
                catch
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }     
        }

        //PUT
        [HttpPut("{sessieID}")]
        public StatusCodeResult Put(int sessieID)
        {
            closeSessions();
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
        public void closeSessions()
        {
            int[] openSessies = (from sessie in _context.sessie
                                    where sessie.actief == true
                                    select sessie.ID).ToArray();

            for(int i = 0; i < openSessies.Length; i++)
            {
                DateTime open = DateTime.Parse(_context.sessie.Find(openSessies[i]).intijd);
                double tijd = (DateTime.Now - open).TotalSeconds;
                Console.WriteLine("Checkt sessie: " + openSessies[i]);
                if(tijd > 1800)
                {
                    sessie huidigeSessie = _context.sessie.Find(openSessies[i]);
                    huidigeSessie.actief = false;
                    huidigeSessie.uittijd = DateTime.Now.ToString();
                    _context.SaveChanges();
                    Console.WriteLine("Inactieve sessie gesloten: " + openSessies[i]);
                }
            }   
        }
        
     }
}
