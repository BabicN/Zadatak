using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.Entity;

namespace MvcApplication1.Controllers
{
    public class DbCRUDController : Controller
    {
        ProizvodDB db = new ProizvodDB();
        public ActionResult Create()
        {
            var listaKategorija = db.Kat.ToList();
            var listaProizvodjaca = db.Pro.ToList();
            var listaDobavljaca = db.Dob.ToList();
            var cModel = new CreateModel { kategorija = listaKategorija, proizvodjac = listaProizvodjaca, dobavljac = listaDobavljaca};

            return View(cModel);
        }

        [HttpPost]
        public ActionResult Create(CreateModel pp)
        {
            if (ModelState.IsValid)
            {
                db.Proiz.Add(pp.proizvod);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
           }
            return RedirectToAction("Index", "Home"); ;
        }

        public ActionResult Edit(int id)
        {
            var listaKategorija = db.Kat.ToList();
            var listaProizvodjaca = db.Pro.ToList();
            var listaDobavljaca = db.Dob.ToList();
            var cModel = new CreateModel { proizvod = db.Proiz.Find(id), kategorija = listaKategorija, proizvodjac = listaProizvodjaca, dobavljac = listaDobavljaca };

            return View(cModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateModel pp)
        {
            try
            {
               var noviProizvod = db.Proiz.ToList().FirstOrDefault(x => x.Id == pp.proizvod.Id);

                noviProizvod.Naziv = pp.proizvod.Naziv;
                noviProizvod.Opis = pp.proizvod.Opis;
                noviProizvod.Cena = pp.proizvod.Cena;
                noviProizvod.KategorijaId = pp.proizvod.KategorijaId;
                noviProizvod.DobavljacId = pp.proizvod.DobavljacId;
                noviProizvod.ProizvodjacId = pp.proizvod.ProizvodjacId;

                db.Entry(noviProizvod).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Delete(int id)
        {
            db.Proiz.Remove(db.Proiz.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            { db.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
