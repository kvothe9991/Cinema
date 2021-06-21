using Cine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cine.Models;


namespace Cine.Controllers
{
    public class CancelacionCompraController : Controller
    {
        private CineContext db = new CineContext();

        // GET: CancelacionCompra
        [HttpGet]
        public ActionResult Index()
        {
            TempData["Result"] = null;
            return View();
        }

        // POST: CancelacionCompra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CancelacionCompra ccm)
        {
            if (ModelState.IsValid)
            {
                Entrada entrada = db.Entradas.Find(ccm.Id);
                ccm.Encontrado = entrada != null;

                if (ccm.Encontrado)
                {
                    ccm.Cancelable = (DateTime.Now - entrada.Horario).Hours > 2;
                    if (ccm.Cancelable)
                        db.Entradas.Remove(entrada);
                }

                TempData["Result"] = ccm;
            }
            return View(ccm);
        }
    }
}