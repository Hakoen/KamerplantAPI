using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mandje_model;

namespace mandje_Controller
{
 [Route("api/[controller]")]
    [ApiController]
    public class mandjeController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public mandjeController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/mandje
        [HttpGet]
        public List<mandje> Get()
        {
            return _context.mandje.ToList();
        }

        // GET api/mandje/5
        [HttpGet("{id}")]
        public mandje Get(int id)
        {
            return _context.mandje.Find(id);
        }

        // POST api/mandje
        [HttpPost]
        public StatusCodeResult Post([FromBody] mandje newMandje)
        {
            try
            {
                _context.mandje.Add(newMandje);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/mandje/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] mandje changedMandje)
        {
            try
            {
                _context.mandje.Update(changedMandje);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/mandje/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                mandje verwijder = _context.mandje.Find(id);
                _context.mandje.Remove(verwijder);
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