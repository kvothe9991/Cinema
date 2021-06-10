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

            // Ricardo le mete query a db buscando id
            // cancela la compra
            // setea ccm

            return View(ccm);
        }
    }
}