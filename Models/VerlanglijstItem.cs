using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class verlanglijstitem
{
    public int productID { get; set; }
    public int geregistreerdeklantID { get; set; }
    public geregistreerdeklant geregistreerdeklant { get; set; }
    public product product { get; set; }
}