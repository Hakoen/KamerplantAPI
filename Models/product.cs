using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using bestellingproduct_model;
using verlanglijstitem_model;

namespace product_model
{
    public class product
    {
        public int ID { get; set; }
        public string naam { get; set;}
        public double prijs { get; set; }
        public string beschrijving { get; set; }
        public string foto { get; set; }
        public int voorraad { get; set; }
        public int categorieID { get; set; }
        public List<bestellingproduct> bestellingen { get; set; }
        public List<verlanglijstitem> verlanglijst { get; set; }
    }
}