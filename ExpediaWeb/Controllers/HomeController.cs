using ArangoDB.Client;
using ExpediaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpediaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Vuelos()
        {
            ViewBag.Message = "Te ofrecemos varias opciones para que viajes cómodo y seguro";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        class newVuelo
        {            
            public string nDesde, nHacia;
            public DateTime nFechaIda, nFechaRegreso;
        }

        [HttpPost]
        public ActionResult Index(ManejarVuelos infovuelo)
        {
            using (ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
            {
                /*var nVuelo = new newVuelo { nDesde = infovuelo.Desde, nHacia = infovuelo.Hacia, 
                    nFechaIda = infovuelo.fechaIda, nFechaRegreso = infovuelo.fechaRegreso};                
                db.Insert<newVuelo>(nVuelo); */

                string destino = db.Query<Viaje>().Where(p => AQL.Contains(p.Origen, infovuelo.Desde)).Select(p => p.Destino).First();
                
                return RedirectToAction("Vuelos");  
            }
        }
    }
}
