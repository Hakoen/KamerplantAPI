using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using geregistreerdeklant_model;
using product_model;

namespace verlanglijstitem_model
{
    public class verlanglijstitem
    {
        public int ID { get; set; }
        public int productID { get; set; }
        public int geregistreerdeklantID { get; set; }
    }
}