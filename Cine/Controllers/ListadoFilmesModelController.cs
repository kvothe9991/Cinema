using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cine.Models;
using Cine.DAL;

namespace Cine.Controllers
{
    public class ListadoFilmesModelController : Controller
    {
        CineContext db = new CineContext();

        public ActionResult Index()
        {
            // ricardo hace query de todos los filmes disponibles y los mete en filmes
            ICollection<Filme> filmes = new List<Filme>();

            return View(new ListadoFilmesModel { Filmes = filmes });
        }
    }
}