using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using bestellingproduct_model;

namespace bestelling_model
{
    public class bestelling 
    {
        public int ID { get; set; }
        public int klantID { get; set; }
        public bool geregistreerd { get; set; }
        public double prijs { get; set; }
        public string datum { get; set; }
        public string adres { get; set; }
        public List<bestellingproduct> producten { get; set; }
        
    }
}