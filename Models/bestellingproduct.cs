using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class bestellingproduct
{
    public int productID { get; set; }
    public product product { get; set; }
    public int bestellingID { get; set; }
    public bestelling bestelling { get; set; }
}