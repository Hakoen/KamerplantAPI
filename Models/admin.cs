using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using geregistreerdeklant_model;
using bestellingproduct_model;
using verlanglijstitem_model;

namespace admin_model
{
    public class admin
    { 
         public int ID { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public List<bestellingproduct> bestellingen  { get; set; }
        public List<verlanglijstitem> verlanglijst { get; set; }
        public string email { get; set; }
        public int werknemersID { get; set; }
    }
}