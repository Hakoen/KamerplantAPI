using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using geregistreerdeklant_model;

namespace geregistreerdeklant.Controllers //Rename the namespace
{
    [Route("geregistreerdeklant/[controller]")] //The route
    [ApiController]
    public class geregistreerdeklantController : ControllerBase //Rename the controller
    {
        private readonly kamerplantContext _context;    //Added context field to easily acces the dotnet context

        public geregistreerdeklantController (kamerplantContext context)
        {
            _context = context; //Constructor to instantiate the dotnet context
        }


        // GET api/geregistreerdeklant
        [HttpGet]
        public IEnumerable<geregistreerdeklant> Get()
        {
            return _context.geregistreerdeklant.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
