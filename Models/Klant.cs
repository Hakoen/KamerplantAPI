using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class klant
{
    public int ID { get; set; }
    public string naam { get; set; }
    public string adres { get; set; }
    public List<bestellingproduct> bestellingen  { get; set; }
}