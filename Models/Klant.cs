using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using bestellingproduct_model;

namespace klant_model
{
    public class klant
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public List<bestellingproduct> bestellingen  { get; set; }
    }
}