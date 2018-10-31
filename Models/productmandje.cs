using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class productmandje
{
    public int productID { get; set; }
    public int mandjeID { get; set; }
    public product product { get; set; }
    public mandje mandje { get; set; }
}