using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class geregistreerdeklant : klant
{
    public List<verlanglijstitem> verlanglijst { get; set; }
    public string email { get; set; }


}