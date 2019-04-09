using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace MvcApplication1.Controllers
{
    public class JsonCRUDController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JsonProizvod proizvod)
        {
            try
            {
                string file = Server.MapPath("~/App_Data/Proizvod.json");
                string Json = System.IO.File.ReadAllText(file);
                List<JsonProizvod> pro = JsonConvert.DeserializeObject<List<JsonProizvod>>(Json);

                int a=0;
                foreach (var item in pro)
                {
                    if (a < item.Id)
                        a=item.Id;
                }
                proizvod.Id = a+1;

                pro.Add(proizvod);
 
                Json = new JavaScriptSerializer().Serialize(pro);  
                System.IO.File.WriteAllText(file, Json); 

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(int id)
        {
            string file = Server.MapPath("~/App_Data/Proizvod.json");
            string Json = System.IO.File.ReadAllText(file);
            List<JsonProizvod> pro = JsonConvert.DeserializeObject<List<JsonProizvod>>(Json);

            JsonProizvod proizvod = null;
            foreach (var item in pro)
            {
                if (id == item.Id)
                    proizvod = item;
            }

            return View(proizvod);
        }

        [HttpPost]
        public ActionResult Edit(int id, JsonProizvod novi)
        {
            try
            {
                string file = Server.MapPath("~/App_Data/Proizvod.json");
                string Json = System.IO.File.ReadAllText(file);
                List<JsonProizvod> pro = JsonConvert.DeserializeObject<List<JsonProizvod>>(Json);

                pro.Remove(pro.Single(r => r.Id == id));

                pro.Add(novi);
                
                Json = new JavaScriptSerializer().Serialize(pro);
                System.IO.File.WriteAllText(file, Json); 

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Delete(int id)
        {
            string file = Server.MapPath("~/App_Data/Proizvod.json");
            string Json = System.IO.File.ReadAllText(file);
            List<JsonProizvod> pro = JsonConvert.DeserializeObject<List<JsonProizvod>>(Json);

            pro.Remove(pro.Single(r => r.Id == id));

            Json = new JavaScriptSerializer().Serialize(pro);
            System.IO.File.WriteAllText(file, Json);

            return RedirectToAction("Index", "Home");
        }
    }
}
