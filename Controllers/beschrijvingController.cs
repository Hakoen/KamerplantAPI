//product[] producten = _context.product.ToArray();

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_model;


namespace beschrijving_Controller
{
 [Route("api/beschrijving")]
    [ApiController]
    public class beschrijvingController : ControllerBase
    {
        private readonly kamerplantContext _context;

        public beschrijvingController(kamerplantContext context)
        {
            _context = context;
        }

        [HttpPut]
        public StatusCodeResult Put()
        {
            try
            {
                
                product[] producten = _context.product.ToArray();
                Random rnd = new Random();

                for (int i = 0; i != (producten.Length); i++ )
                {
                    int randomizer = rnd.Next(1,10);
                    switch(randomizer){
                        case (1):
                            producten[i].beschrijving = "Deze mooie " + producten[i].naam + " is de leukste en lekkerst ruikenede toevoeging tot je woonkamer, nu voor slechts €" + producten[i].prijs.ToString() + "!";
                            break;
                        case (2):
                            producten[i].beschrijving = producten[i].naam + " is de essentiele plant waar een huishouden om draait, geen " + producten[i].naam + ", geen lente. Investeer daarom snel in een warme zomer! Dat is zeker voor de prijs van: €" + producten[i].prijs + " geen geld.";
                            break;
                        case (3):
                            producten[i].beschrijving = "Sommigen geven hun ouders een oudejaarslot cadeau, maar wat moeten ze daarmee als je ook een " + producten[i].naam + " kan krijgen. En alleen bij kamerplant.me he! KOOP DAN, voor slechts: €" + producten[i].prijs;
                            break;
                        case (4):
                            producten[i].beschrijving = "De elegante " + producten[i].naam + "is de plant die u in huis dient te hebben. Deze zal niet alleen met Kerst een pronkstuk op uw tafel zijn, maar het hele jaar door. Nu voor slechts €" + producten[i].prijs.ToString() + "!";
                            break;
                        case (5):
                            producten[i].beschrijving = producten[i].naam + " is een oud belangrijk soort met een heerlijke geur die uw woonkamer laat bloeien. Ook kunnen ze heel goed bewaard worden waardoor ze lang mee gaan. Bestel nu voor slechts €" + producten[i].prijs.ToString() + "!";
                            break;
                        case (6):
                            producten[i].beschrijving = "Neem het zonnetje in huis met de enige echte " + producten[i].naam + " Het is een sterk soort die die al jaren meegaat. " + producten[i].naam + " is bij velen favoriet en terecht. Bestel nu het nog kan voor maar € " + producten[i].prijs.ToString() + "!";
                            break;
                        case (7):
                            producten[i].beschrijving = "Koop deze overheerlijke " + producten[i].naam + " nu exclusief bij kamerplant.me, voor slechts €" + producten[i].prijs.ToString() + "!";
                            break;
                        case (8):
                            producten[i].beschrijving = "Deze mooie " + producten[i].naam + " is alleen maar te koop bij kamerplant.me, koop h'm daarom snel voor maar €" + producten[i].prijs.ToString() + "!";
                            break;
                        case (9):
                            producten[i].beschrijving = "Voor slechts "  + producten[i].prijs.ToString() + " kunt u nu al deze mooie " + producten[i].naam + " in huis halen!";
                            break;
                        case (10):
                            producten[i].beschrijving = "Deze " + producten[i].naam + " is de aller laatste die we uit China konden trekken, hierna sterft ie uit! Kopen nu het nog kan dus, zeker voor een prijsje van slechts: €" + producten[i].prijs.ToString() + "!";
                            break;
                        default: //Komt eigenlijk niet voor, daarom dubbel met case 10:
                            producten[i].beschrijving = "Deze " + producten[i].naam + " is de aller laatste die we uit China konden trekken, hierna sterft ie uit! Kopen nu het nog kan dus, zeker voor een prijsje van slechts: €" + producten[i].prijs.ToString() + "!";
                            break; 
                    } 
                    _context.SaveChanges();     

                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}