using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using verlanglijstitem_model;
using bestellingproduct_model;

namespace geregistreerdeklant_model
{
    public class geregistreerdeklant
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public List<bestellingproduct> bestellingen  { get; set; }
        public List<verlanglijstitem> verlanglijst { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }

    }
}