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

        public class RequestOrder
        {
            public int klantID { get; set; }
            public int bestellingID { get; set; }
            public product[] producten { get; set; } //Product ID's
            public bool geregistreerd { get; set; }
            public string adres { get; set; }
            public double prijs {get; set; }
            public string status { get; set; }
        }

        // GET api/
        [HttpGet]
        public RequestOrder[] Get()
        {
            
            bestelling[] bestellingen = _context.bestelling.ToArray();
            RequestOrder[] alleBestellingen = new RequestOrder[bestellingen.Length];

            for(int i = 0; i < bestellingen.Length; i++)
            {
                int[] productenInBestelling = (from combi in _context.bestellingproduct
                    where (combi.bestellingID == bestellingen[i].ID)
                    select combi.productID).ToArray();

                RequestOrder requestOrder = new RequestOrder();
                product[] producten = new product[productenInBestelling.Length];

                

                for(int x = 0; x < productenInBestelling.Length; x++){
                    product HuidigProduct = _context.product.Find(productenInBestelling[x]);
                    producten[x] = HuidigProduct;
                }

                requestOrder.adres = bestellingen[i].adres;
                requestOrder.bestellingID = bestellingen[i].ID;
                requestOrder.geregistreerd = bestellingen[i].geregistreerd;
                requestOrder.klantID = bestellingen[i].klantID;
                requestOrder.producten = producten;
                requestOrder.prijs = bestellingen[i].prijs;
                requestOrder.status = bestellingen[i].status;
                alleBestellingen[i] = requestOrder;

            }

            return alleBestellingen;


        }

    	
        // GET api/bestelling/5
        [HttpGet("{id}")]
        public RequestOrder Get(int id)
        {
            RequestOrder requestOrder = new RequestOrder();

            bestelling Bestelling = _context.bestelling.Find(id);

            int[] productenInBestelling = (from combi in _context.bestellingproduct
                    where (combi.bestellingID == id)
                    select combi.productID).ToArray();

            product[] producten = new product[productenInBestelling.Length];

            for(int i = 0; i < productenInBestelling.Length; i++){
                product HuidigProduct = _context.product.Find(productenInBestelling[i]);
                producten[i] = HuidigProduct;
            }

            
            requestOrder.adres = Bestelling.adres;
            requestOrder.bestellingID = Bestelling.ID;
            requestOrder.geregistreerd = Bestelling.geregistreerd;
            requestOrder.klantID = Bestelling.klantID;
            requestOrder.producten = producten;
            requestOrder.prijs = Bestelling.prijs;
            requestOrder.status = Bestelling.status;
            return requestOrder;
        }

        //Definitie van te ontvangen order object
        public class Order
        {
            public int klantID { get; set; }
            public int[] producten { get; set; } //Product ID's
            public bool geregistreerd { get; set; }
            public string adres { get; set; }
        }

        // POST api/bestelling
        [HttpPost]
        public StatusCodeResult Post([FromBody] Order order)
        {
            //Boolean to determine if order can be placed
            bool allProductsInStock = true;

            //Bestelling
            bestelling newBestelling = new bestelling();
            newBestelling.datum = DateTime.Now.ToString();
            newBestelling.prijs = 4.95;
            newBestelling.klantID = order.klantID;
            newBestelling.adres = order.adres;
            newBestelling.geregistreerd = order.geregistreerd;
            newBestelling.status = "Onbehandeld";

            //Bestelling opbouwen uit aangeleverde json
            //Bestellingproduct krijgen wij binnen als array product ID's
            for(int i = 0;i < order.producten.Length; i++)
            {
                //Check of product in voorraad is.
                product Product = _context.product.Find(order.producten[i]);
                bool productInVoorraad = (Product.voorraad > 0) ? true : false;

                if (productInVoorraad)
                {
                    //Product voorraad met 1 verminderen
                    Product.voorraad -= 1;

                    //bestellingproduct relatie opbouw:
                    bestellingproduct productCombinatie = new bestellingproduct();
                    productCombinatie.productID = order.producten[i];
                    productCombinatie.bestellingID = newBestelling.ID;
                    productCombinatie.product = Product;
                    productCombinatie.bestelling = newBestelling;
                    productCombinatie.verkoopPrijs = _context.product.Find(order.producten[i]).prijs;
                    _context.bestellingproduct.Add(productCombinatie);
                    newBestelling.producten.Append(productCombinatie);
                    newBestelling.prijs = (newBestelling.prijs + productCombinatie.verkoopPrijs);
                } 
                else 
                {
                    allProductsInStock = false;
                }
            }

            if(allProductsInStock)
            {
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
            else
            {
                return StatusCode(410); //Een van de producten niet in voorrraad
            }

        }
    }
}
