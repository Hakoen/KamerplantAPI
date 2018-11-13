using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bestelling_model;
using klant_model;
using bestellingproduct_model;
using product_model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bestelling_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bestellingController : ControllerBase
    {

        private readonly kamerplantContext _context;

        public bestellingController(kamerplantContext context)
        {
            _context = context;
        }


        // GET api/admin
        [HttpGet]
        public List<bestelling> Get()
        {
            return _context.bestelling.ToList();
        }

        // GET api/bestelling/5
        [HttpGet("{id}")]
        public bestelling Get(int id)
        {
                return _context.bestelling.Find(id);
        }

        //Definitie van te ontvangen order object
        public class Order{
            public int klantID { get; set; }
            public int[] producten { get; set; } //Product ID's
        }

        // POST api/bestelling
        [HttpPost]
        public StatusCodeResult Post([FromBody] Order order)
        {
            //Bestelling
            bestelling newBestelling = new bestelling();
            Console.WriteLine(order.klantID + " hij ontvangt hm");
                
                newBestelling.datum = DateTime.Now.ToString();
                newBestelling.prijs = 0.00;
            

            //Bestelling opbouwen uit aangeleverde json
            //Bestellingproduct krijgen wij binnen als array product ID's
            for(int i = 0;i < order.producten.Length; i++)
            {
                bestellingproduct productCombinatie = new bestellingproduct();
                productCombinatie.productID = order.producten[i];
                productCombinatie.bestellingID = newBestelling.ID;
                productCombinatie.product = _context.product.Find(order.producten[i]);
                productCombinatie.bestelling = newBestelling;
                productCombinatie.verkoopPrijs = _context.product.Find(order.producten[i]).prijs;

                _context.bestellingproduct.Add(productCombinatie);
                newBestelling.producten.Append(productCombinatie);
                newBestelling.prijs = (newBestelling.prijs + productCombinatie.verkoopPrijs);
            }
            newBestelling.klantID = order.klantID;
            try
            {
                _context.bestelling.Add(newBestelling);
                _context.SaveChanges();
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
            
        }

        // PUT api/bestelling    ID meesturen in JSON
        [HttpPut]
        public StatusCodeResult Put([FromBody] bestelling changedBestelling)
        {
            try
            {
                _context.bestelling.Update(changedBestelling);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/bestelling/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                bestelling verwijder = _context.bestelling.Find(id);
                _context.bestelling.Remove(verwijder);
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
