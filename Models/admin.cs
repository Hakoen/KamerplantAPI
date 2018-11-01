using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using geregistreerdeklant_model;

namespace admin_model
{
    public class admin : geregistreerdeklant
    { 
        public int werknemersID { get; set; }
    }
}