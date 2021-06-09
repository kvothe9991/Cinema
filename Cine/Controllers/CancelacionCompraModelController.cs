using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cine.Models;
using Cine.DAL;

namespace Cine.Controllers
{
    public class CancelacionCompraModelController : Controller
    {
        private CineContext db = new CineContext();

        public ActionResult Index(int id)
        {
            if (id == 0)
                return View(new CancelacionCompraModel { });

            // Ricardo le mete query a db buscando id
            // cancela la compra
            // resuelve estas dos variables
            bool cancelable = false;
            bool encontrado = false;

            return View(new CancelacionCompraModel { Id = id, Cancelable = cancelable, Encontrado = encontrado });
        }
    }
}