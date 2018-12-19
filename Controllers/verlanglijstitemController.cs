using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using verlanglijstitem_model;

namespace verlanglijstitem_Controller
{
 [Route("api/[controller]")]
 [ApiController]
    public class verlanglijstitemController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public verlanglijstitemController(kamerplantContext context)
        {
            _context = context;
        }

        // GET api/verlanglijstitem
        [HttpGet]
        public List<verlanglijstitem> Get()
        {
            return _context.verlanglijstitem.ToList();
        }

        // GET api/verlanglijstitem/5
        //ID is hier klant ID, waaraan de lijst items gelinkt zijn
        [HttpGet("{id}")]
        public verlanglijstitem[] Get(int id)
        {
            verlanglijstitem[] inVerlanglijst = (from item in _context.verlanglijstitem
                                    where (item.geregistreerdeklantID == id)
                                    select item).ToArray();
            return inVerlanglijst;
        }

        // POST api/verlanglijstitem
        [HttpPost]
        public StatusCodeResult Post([FromBody] verlanglijstitem newVerlanglijstitem)
        {
            int gebruikerID = newVerlanglijstitem.geregistreerdeklantID;
            int[] inVerlanglijst = (from item in _context.verlanglijstitem
                                    where (item.geregistreerdeklantID == gebruikerID)
                                    select item.productID).ToArray();

            try
            { 
                //Als gebruiker dit item nog niet op verlanglijst heeft:
                if(inVerlanglijst.Contains(newVerlanglijstitem.productID)){
                    return Ok();
                } else {
                    _context.verlanglijstitem.Add(newVerlanglijstitem);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/verlanglijstitem/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] verlanglijstitem changedVerlanglijstitem)
        {
            try
            {
                _context.verlanglijstitem.Update(changedVerlanglijstitem);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/verlanglijstitem/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                verlanglijstitem verwijder = _context.verlanglijstitem.Find(id);
                _context.verlanglijstitem.Remove(verwijder);
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