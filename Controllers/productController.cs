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
        [HttpGet]    //default values needed to prevent crash
        public List<product> Get(int pageSize = 40, string page = "1", string query = "", int cid = 0)
        {
            // 1	Bloembollen
            // 2	Fruitbomen
            // 3	Kamerplanten
            // 4	Rozen
            // 5	Zaden
            /* id=pageSize voorraad=total_pages categorieID=page(huidige pagina index dus)
            vieze hack*/
            product filler = new product(); 
            List<product> unsortedlist = _context.product.ToList();
            List<product> productlist = unsortedlist.OrderBy(o=>o.ID).ToList();

            if ( cid > 0)
            {
                productlist = productlist.Where( x => x.categorieID == cid).ToList();
            }


            if ( query.Length > 0)
            {
                productlist = productlist.Where( x => x.naam.ToLower().Contains(query.ToLower())).ToList();
            }



            int page1;
            /* check om te kijken of page een nummer is want frontend geeft
            undefined door op pag1 wat een typeerror veroorzaak*/
            page1 = (int.TryParse(page.ToString (), out int Num)) ? page1 = int.Parse(page) : page1 = 1;       
            filler.ID = (pageSize > productlist.Count()) ? productlist.Count() : pageSize;
            filler.voorraad = Convert.ToInt32(Math.Ceiling((productlist.Count()/Convert.ToDouble(pageSize))));
            filler.categorieID = page1;
            int offset = (page1 - 1) * pageSize;

            //outofbounds check
            if ((offset+pageSize)>productlist.Count())
            {
                productlist.Insert(productlist.Count(),filler);
                return productlist.GetRange(offset, productlist.Count()-offset);
            }
            else
            {
                productlist.Insert(offset+pageSize,filler);
                return productlist.GetRange(offset, pageSize+1);
            }
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
                

                  //  .__(.)< (MEOW)
                  //   \___)   
                
                
                
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