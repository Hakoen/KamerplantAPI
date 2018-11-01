using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using klant_model;

namespace klant_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class klantController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public klantController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/klant
        [HttpGet]
        public List<klant> Get()
        {
            return _context.klant.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public klant Get(int id)
        {
            return _context.klant.Find(id);
        }

        // POST api/values
        [HttpPost]
        public StatusCodeResult Post([FromBody] klant newCustomer)
        {
            try
            {
                _context.klant.Add(newCustomer);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] klant changedCustomer)
        {
            try
            {
                _context.klant.Update(changedCustomer);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                klant verwijder = _context.klant.Find(id);
                _context.klant.Remove(verwijder);
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
