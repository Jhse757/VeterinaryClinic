using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VeterinaryClinic.Models.Interfaces;

namespace VeterinaryClinic.Data
{
    public class AplicationDbContext : DbContext
    {

        // Configuracion del DBcontext
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
        : base(options){}


        // Registro de interfaces de los modelos
        public DbSet<Owner> Owners { get; set;} 
        public DbSet<Pet> Pets { get; set;} 
        public DbSet<Vet> Vets { get; set;} 
        public DbSet<Quote> Quotes { get; set;}

        // Configuracion de relaciones entre tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
            .HasOne(p =>p.Owner)
            .WithMany(o => o.Pets)
            .HasForeignKey(o => o.Owner_Id);

            modelBuilder.Entity<Quote>()
            .HasOne(q =>q.Pet)
            .WithMany(p => p.Quotes)
            .HasForeignKey(q => q.Vet_Id);

            modelBuilder.Entity<Quote>()
            .HasOne(q =>q.Vet)
            .WithMany(v => v.Quotes)
            .HasForeignKey(q => q.Vet_Id);
        }
    }
}