using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using klant_model;
using bestelling_model;
using geregistreerdeklant_model;
using product_model;
using categorie_model;
using verlanglijstitem_model;
using bestellingproduct_model;
using sessie_model;

public class kamerplantContext : DbContext
{
    public DbSet<klant> klant { get; set; }
    public DbSet<geregistreerdeklant> geregistreerdeklant { get; set; }
    public DbSet<bestelling> bestelling { get; set; }
    public DbSet<bestellingproduct> bestellingproduct { get; set; }
    public DbSet<product> product { get; set; }
    public DbSet<categorie> categorie { get; set; }
    public DbSet<verlanglijstitem> verlanglijstitem { get; set; }
    public DbSet<sessie> sessie { get; set; }
    
    public kamerplantContext (DbContextOptions<kamerplantContext> options) : base (options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //M-M producten & bestellingen
        modelBuilder.Entity<bestellingproduct>()
            .HasKey(t => new {t.ID});
        modelBuilder.Entity<bestellingproduct>()
            .HasOne(b => b.bestelling)
            .WithMany(p => p.producten);
        modelBuilder.Entity<bestellingproduct>()
            .HasOne(p => p.product)
            .WithMany(b => b.bestellingen);
    }

}