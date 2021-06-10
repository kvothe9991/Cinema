using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cine.Models;
using Cine.DAL;

namespace Cine.Controllers
{
    public class FilmeController : Controller
    {
        private CineContext db = new CineContext();

        public ActionResult Index(int id)
        {
            Filme f = new Filme { };

            if (id != 0)
            {
                // Ricardo tira query pa ver si lo encuentra
                // y setea f
            }

            return View(f);
        }
    }
}