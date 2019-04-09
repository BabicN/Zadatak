namespace MvcApplication1.Migrations
{
    using System.Data.Entity.Migrations;
    using Entiteti;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Models.ProizvodDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcApplication1.Models.ProizvodDB context)
        {
            context.Kat.AddOrUpdate(x => x.Tip,
                new Kategorija {Tip = "Hrana" },
                new Kategorija {Tip = "Odeca" });

            context.Dob.AddOrUpdate(x => x.Ime,
                new Dobavljac { Ime = "Dobavljac 1" },
                new Dobavljac { Ime = "Dobavljac 2" });

            context.Pro.AddOrUpdate(x => x.Naziv,
                new Proizvodjac { Naziv = "Neka Kompanija 1" },
                new Proizvodjac { Naziv = "Neka Kompanija 2" },
                new Proizvodjac { Naziv = "Neka Kompanija 3" });

          context.Proiz.AddOrUpdate(x => x.Naziv,
               new Proizvod { Naziv = "Hleb", Cena = 50, Opis = "fjhgjfdhdf", KategorijaId = 3, DobavljacId = 4, ProizvodjacId = 1 },
               new Proizvod { Naziv = "Mleko", Cena = 90, Opis = "fjhtryrutgjfdhdf", KategorijaId = 3, DobavljacId = 3, ProizvodjacId = 2 },
               new Proizvod { Naziv = "Jogurt", Cena = 190, Opis = "fjh", KategorijaId = 3, DobavljacId = 3, ProizvodjacId = 2 },
               new Proizvod { Naziv = "Pantalone", Cena = 2890, Opis = "kul", KategorijaId = 4, DobavljacId = 3, ProizvodjacId = 3 });
        }
    }
}
