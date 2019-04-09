using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using Newtonsoft.Json;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        ProizvodDB db = new ProizvodDB();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ViewJson()
        {
            string file = Server.MapPath("~/App_Data/Proizvod.json");
            string Json = System.IO.File.ReadAllText(file);
            List<JsonProizvod> pro = JsonConvert.DeserializeObject<List<JsonProizvod>>(Json);
            return PartialView(pro);
        }

        public PartialViewResult ViewDb()
        {
            return PartialView(db.Proiz.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (db != null)
            { db.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
