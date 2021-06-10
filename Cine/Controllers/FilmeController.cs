using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cine.Models;
using Cine.DAL;
using System.Net;

namespace Cine.Controllers
{
    public class FilmeController : Controller
    {
        private CineContext db = new CineContext();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }
    }
}