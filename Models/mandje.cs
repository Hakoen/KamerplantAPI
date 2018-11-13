using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using productmandje_model;

namespace mandje_model
{
    public class mandje
    {
        public int ID { get; set; }
        public int klantID { get; set; }
        public List<productmandje> producten { get; set; }
    }
}