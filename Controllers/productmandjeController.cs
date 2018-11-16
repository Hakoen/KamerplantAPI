using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productmandje_model;

namespace productmandje_Controller
{
 [Route("api/[controller]")]
    [ApiController]
    public class productmandjeController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public productmandjeController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/productmandje
        [HttpGet]
        public List<productmandje> Get()
        {
            return _context.productmandje.ToList();
        }

        // GET api/productmandje/5
        [HttpGet("{id}")]
        public productmandje Get(int id)
        {
            return _context.productmandje.Find(id);
        }

        // POST api/productmandje
        [HttpPost]
        public StatusCodeResult Post([FromBody] productmandje newProductMandje)
        {
            try
            {
                _context.productmandje.Add(newProductMandje);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/productmandje/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] productmandje changedProductMandje)
        {
            try
            {
                _context.productmandje.Update(changedProductMandje);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/productmandje/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                productmandje verwijder = _context.productmandje.Find(id);
                _context.productmandje.Remove(verwijder);
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