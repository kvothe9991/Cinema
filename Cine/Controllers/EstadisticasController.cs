using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cine.DAL;

namespace Cine.Controllers
{
    public class EstadisticasController : Controller
    {
        private CineContext db = new CineContext();

        // GET: Estadisticas
        public ActionResult Index()
        {
            // Se preparan los datos

            return View(/* un object con las estadisticas */);
        }
    }
}
