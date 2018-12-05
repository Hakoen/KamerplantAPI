using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using geregistreerdeklant_model;

namespace geregistreerdeklant_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class geregistreerdeklantController : ControllerBase
    {

        private readonly kamerplantContext _context;

        public geregistreerdeklantController(kamerplantContext context)
        {
            _context = context;
        }


        // GET api/geregistreerdeklant
        [HttpGet]
        public List<geregistreerdeklant> Get()
        {
            return _context.geregistreerdeklant.ToList();
        }

        //GET api/geregistreerdeklant/henk@gmail.com
        [HttpGet("{mail}")]
        public geregistreerdeklant Get(string mail)
        {
            Console.WriteLine("Zoeken naar email: " + mail);
            geregistreerdeklant _gebruiker = _context.geregistreerdeklant.SingleOrDefault(geregistreerdeklant => geregistreerdeklant.email == mail.ToLower());
            Console.WriteLine(_gebruiker.naam);
            return _gebruiker;
        }


        // POST api/geregistreerdeklant
        [HttpPost]
        public StatusCodeResult Post([FromBody] geregistreerdeklant newCustomer)
        {
            try
            {
                newCustomer.email = newCustomer.email.ToLower();
                _context.geregistreerdeklant.Add(newCustomer);
                _context.SaveChanges();
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // PUT api/geregistreerdeklant/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] geregistreerdeklant changedCustomer)
        {
            try
            {
                string mail = changedCustomer.email.ToLower();
                changedCustomer.email = mail;
                _context.geregistreerdeklant.Update(changedCustomer);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/geregistreerdeklant/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                geregistreerdeklant verwijder = _context.geregistreerdeklant.Find(id);
                _context.geregistreerdeklant.Remove(verwijder);
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
