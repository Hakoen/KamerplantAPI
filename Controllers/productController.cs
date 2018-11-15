using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_model;

namespace product_Controller
{
 [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public productController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/product
        [HttpGet]
        public List<product> Get()
        {
            return _context.product.ToList();
            
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public product Get(int id)
        {
            return _context.product.Find(id);
        }

        // POST api/product
        [HttpPost]
        public StatusCodeResult Post([FromBody] product newProduct)
        {
            try
            {
                _context.product.Add(newProduct);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

//[FromBody] product changedProduct

        // PUT api/product/5
        [HttpPut]
        public StatusCodeResult Put()
        {
            try
            {
            
                product[] producten = _context.product.ToArray();
                Random rnd = new Random();

                for (int i = 0; i != (producten.Length); i++ )
                {
                    if (producten[i].voorraad == 0 )
                    
                        producten[i].voorraad = 
                        producten[i].voorraad + rnd.Next(1000, 9000); 
                         

                }
                


                
                
                
                //_context.product.Update(changedProduct);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                product verwijder = _context.product.Find(id);
                _context.product.Remove(verwijder);
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