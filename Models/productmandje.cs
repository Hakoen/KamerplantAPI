using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using product_model;
using mandje_model;

namespace productmandje_model
{
    public class productmandje
    {
        public int productID { get; set; }
        public int mandjeID { get; set; }
        public product product { get; set; }
        public mandje mandje { get; set; }
    }
}