using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using product_model;
using bestelling_model;

namespace bestellingproduct_model
{
    public class bestellingproduct
    {
        public int productID { get; set; }
        public product product { get; set; }
        public int bestellingID { get; set; }
        public bestelling bestelling { get; set; }
        public double verkoopPrijs { get; set; }
    }
}