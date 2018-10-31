using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
public class product
{
    public int ID { get; set; }
    public string naam { get; set;}
    public double prijs { get; set; }
    public string beschrijving { get; set; }
    public string foto { get; set; }
    public string url { get; set; }
    public int voorraad { get; set; }
    public int categorieID { get; set; }
    public List<bestellingproduct> bestellingen { get; set; }
    public List<verlanglijstitem> verlanglijst { get; set; }
    public List<productmandje> mandjes { get; set; }
}