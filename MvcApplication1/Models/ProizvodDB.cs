using System.Data.Entity;
using Entiteti;

namespace MvcApplication1.Models
{
    public class ProizvodDB: DbContext
    {
        public ProizvodDB(): base("DefaultConnection")
        {

        }
        public DbSet<Proizvod> Proiz { get; set; }
        public DbSet<Kategorija> Kat { get; set; }
        public DbSet<Dobavljac> Dob { get; set; }
        public DbSet<Proizvodjac> Pro { get; set; }
    }
}