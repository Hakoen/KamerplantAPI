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

namespace bestellingen_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bestellingenController : ControllerBase
    {

        private readonly kamerplantContext _context;

        public bestellingenController(kamerplantContext context)
        {
            _context = context;
        }


        // GET api/bestelling/5 KLANT ID RETURNT ALLE BESTELLING ID's
        [HttpGet("{id}")]
        public int[] Get(int id)
        {
            int[] klantBestellingen = (from bestelling in _context.bestelling
                    where (bestelling.geregistreerd == true && bestelling.klantID == id)
                    select bestelling.ID).ToArray();
            
            return klantBestellingen;
        }

        public class bestellingUpdate {
            public string newStatus { get; set; }
        }


        [HttpPut("{id}")]
        public bestelling Put([FromBody] bestellingUpdate bestellingupdate, int id)
        {
            Console.WriteLine("bestellingUpdate: " + bestellingupdate);
            bestelling Bestelling = _context.bestelling.Find(id);
            Bestelling.status = bestellingupdate.newStatus;

            _context.bestelling.Update(Bestelling);
            _context.SaveChanges();
            return Bestelling;
        }

        

        [HttpDelete("{id}")]
        public bestelling Delete(int id)
        {
            bestelling Bestelling = _context.bestelling.Find(id);
            _context.bestelling.Remove(Bestelling);
            _context.SaveChanges();
            return Bestelling;
        }

        
    }
}
