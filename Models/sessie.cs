using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace sessie_model
{
    public class sessie
    {
        public int ID { get; set; }
        public int geregistreerdeklantID { get; set; }
        public bool actief { get; set; }
        public string intijd {get; set; }
        public string uittijd { get; set; }
    }
}