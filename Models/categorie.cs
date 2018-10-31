using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class categorie
{
    public int ID { get; set; }
    public string naam { get; set; }
    public string beschrijving  { get; set; } //description te laten zien op cateogorie pagina
    public string foto { get; set; }
    public string url { get; set; } //url naar categorie pagina
    public List<product> producten { get; set; }
}