using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using categorie_model;
using product_model;

namespace categorie_Controller
{
 [Route("api/[controller]")]
 [ApiController]
    public class categorieController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public categorieController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/categorie
        [HttpGet]
        public categorieprod[] Get()
        {
            var categorieproducts = ( from c in _context.categorie
                                        let producten = (
                                        from p in _context.product 
                                        where c.ID == p.categorieID
                                        select p).ToArray()
                                        select new categorieprod(){categorie=c, products=producten}
                                        ).ToArray();
                            
            return categorieproducts;
           
        }
        public class categorieprod
        {
            public categorie categorie { get; set; }
            public product[] products { get; set; }
        }

        // GET api/categorie/5
        [HttpGet("{id}")]
        public categorie Get(int id)
        {
            return _context.categorie.Find(id);
        }

        // POST api/categorie
        [HttpPost]
        public StatusCodeResult Post([FromBody] categorie newCategorie)
        {
            try
            {
                _context.categorie.Add(newCategorie);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/categorie/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] categorie changedCategorie)
        {
            try
            {
                _context.categorie.Update(changedCategorie);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/categorie/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                categorie verwijder = _context.categorie.Find(id);
                _context.categorie.Remove(verwijder);
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