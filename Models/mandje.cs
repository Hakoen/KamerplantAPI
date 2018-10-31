using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class mandje
{
    public int ID { get; set; }
    public int klantID { get; set; }
    public List<productmandje> producten { get; set; }
}