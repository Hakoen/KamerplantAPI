using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sessie_model;
using geregistreerdeklant_model;

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
     }
}
