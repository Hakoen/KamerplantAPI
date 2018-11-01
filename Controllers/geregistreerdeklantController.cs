using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using geregistreerdeklant_model;

namespace kamerplanten_api.Controllers
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


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public StatusCodeResult Post([FromBody] geregistreerdeklant newCustomer)
        {
            try
            {
                geregistreerdeklant user = new geregistreerdeklant
                {
                    naam = newCustomer.naam,
                    adres = newCustomer.adres,
                    email = newCustomer.email,
                    wachtwoord = newCustomer.wachtwoord
                };
                _context.geregistreerdeklant.Add(user);
                _context.SaveChanges();
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
