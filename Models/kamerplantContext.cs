using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using klant_model;
using bestelling_model;
using geregistreerdeklant_model;
using product_model;
using categorie_model;
using verlanglijstitem_model;
using bestellingproduct_model;
using productmandje_model;
using mandje_model;
using admin_model;

public class kamerplantContext : DbContext
{
    public DbSet<klant> klant { get; set; }
    public DbSet<geregistreerdeklant> geregistreerdeklant { get; set; }
    public DbSet<bestelling> bestelling { get; set; }
    public DbSet<bestellingproduct> bestellingproduct { get; set; }
    public DbSet<product> product { get; set; }
    public DbSet<categorie> categorie { get; set; }
    public DbSet<verlanglijstitem> verlanglijstitem { get; set; }
    public DbSet<mandje> mandje { get; set; }
    public DbSet<productmandje> productmandje { get; set; }
    public DbSet<admin> admin { get; set; }
    
    public kamerplantContext (DbContextOptions<kamerplantContext> options) : base (options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //M-M producten & bestellingen
        modelBuilder.Entity<bestellingproduct>()
            .HasKey(t => new {t.bestellingID, t.productID});
        modelBuilder.Entity<bestellingproduct>()
            .HasOne(b => b.bestelling)
            .WithMany(p => p.producten)
            .HasForeignKey(b => b.bestellingID);
        modelBuilder.Entity<bestellingproduct>()
            .HasOne(p => p.product)
            .WithMany(b => b.bestellingen)
            .HasForeignKey(p => p.productID);

        //M-M producten & verlanglijstjes
        modelBuilder.Entity<verlanglijstitem>()
            .HasKey(w => new {w.productID, w.geregistreerdeklantID});
        modelBuilder.Entity<verlanglijstitem>()
            .HasOne(k => k.geregistreerdeklant)
            .WithMany(v => v.verlanglijst)
            .HasForeignKey(k => k.geregistreerdeklantID);
        modelBuilder.Entity<verlanglijstitem>()
            .HasOne(v => v.product)
            .WithMany(k => k.verlanglijst)
            .HasForeignKey(v => v.productID);

        //M-M producten & winkelmandjes
        modelBuilder.Entity<productmandje>()
            .HasKey(pm => new {pm.productID, pm.mandjeID});
        modelBuilder.Entity<productmandje>()
            .HasOne(m => m.mandje)
            .WithMany(p => p.producten)
            .HasForeignKey(m => m.mandjeID);
        modelBuilder.Entity<productmandje>()
            .HasOne(p => p.product)
            .WithMany(m => m.mandjes)
            .HasForeignKey(p => p.productID);
    }
}