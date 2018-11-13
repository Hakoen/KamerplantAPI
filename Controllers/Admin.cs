using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using admin_model;

namespace admin_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminController : ControllerBase
    {

        private readonly kamerplantContext _context;

        public adminController(kamerplantContext context)
        {
            _context = context;
        }


        // GET api/admin
        [HttpGet]
        public List<admin> Get()
        {
            return _context.admin.ToList();
        }

        // GET api/geregistreerdeklant/5
        [HttpGet("{id}")]
        public admin Get(int id)
        {
                return _context.admin.Find(id);
        }

        // POST api/admin
        [HttpPost]
        public StatusCodeResult Post([FromBody] admin newAdmin)
        {
            try
            {
                _context.admin.Add(newAdmin);
                _context.SaveChanges();
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // PUT api/admin/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] admin changedAdmin)
        {
            try
            {
                _context.admin.Update(changedAdmin);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/admin/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                admin verwijder = _context.admin.Find(id);
                _context.admin.Remove(verwijder);
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
