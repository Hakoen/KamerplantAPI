using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class bestelling 
{
    public int ID { get; set; }
    public int klantID { get; set; }
    public double prijs { get; set; }
    public List<bestellingproduct> producten { get; set; }
    
}