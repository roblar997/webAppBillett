using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Models;

namespace webAppBillett.Contexts
{
    public class BillettContext : DbContext
    {

        public BillettContext(DbContextOptions<BillettContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Lugar> lugarer { get; set; }
        public DbSet<Betaling> betaling { get; set; }
        public DbSet<Billett> billetter { get; set; }
        public DbSet<Rute> ruter { get; set; }
        public DbSet<Havn> havn { get; set; }

        public DbSet<RuteForekomstDato> ruteForekomstDato { get; set; }
        public DbSet<RuteForekomstDatoTid> ruteForekomstDatoTid { get; set; }
        public DbSet<RuteForekomstDatoTidKjoretoy> ruteForekomstDatoTidKjoretoy { get; set; }
        public DbSet<Person> personer { get; set; }
        public DbSet<Bagasje> bagasje { get; set; }
        public DbSet<BillettKjoretoy> billettkjoretoy { get; set; }
        public DbSet<Kjoretoy> kjoretoy { get; set; }
        public DbSet<Reservasjon> reservasjon { get; set; }
        public DbSet<BillettPerson> billettPerson { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservasjon>().HasKey(table => new {
                table.billettId,
                table.lugarId
            });


            modelBuilder.Entity<BillettPerson>().HasKey(table => new {
                table.billettId,
                table.personId
            });

            modelBuilder.Entity<BillettKjoretoy>().HasKey(table => new {
                table.billettId,
                table.kjoretoyId
            });
            modelBuilder.Entity<RuteForekomstDatoTidKjoretoy>().HasKey(table => new {
                table.ruteForekomstDatoTidId,
                table.kjoretoyId
            });


            // base.OnModelCreating(modelBuilder);

        }

    }
}
