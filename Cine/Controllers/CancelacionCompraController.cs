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
        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CancelacionCompra ccm = new CancelacionCompra { };

            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                ccm.Cancelable = false;
                ccm.Encontrado = false;
            }
            else
            {
                ccm.Encontrado = true;
                if((DateTime.Now - entrada.Horario).Hours > 2)
                {
                    ccm.Cancelable = true;
                    db.Entradas.Remove(entrada);
                }
                else
                {
                    ccm.Cancelable = false;
                }
            }

            return View(ccm);
        }
    }
}