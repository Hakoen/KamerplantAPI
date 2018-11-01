using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using klant_model;
using verlanglijstitem_model;

namespace geregistreerdeklant_model
{
    public class geregistreerdeklant : klant
    {
        public List<verlanglijstitem> verlanglijst { get; set; }
        public string email { get; set; }


    }
}