using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Cine.DAL;
using Cine.Models;
using Cine.ViewModels;
using System.Web.Mvc;

namespace Cine.Controllers
{
    public class CompraController : Controller
    {
        private CineContext db = new CineContext();

        // GET: Compra
        public ActionResult Index()
        {
            return View(db.Filmes.Where(f => f.Disponible).ToList());
        }

        // GET: Compra/Details
        public ActionResult Details(int? id)
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

        // GET: Compra/Comprar
        [HttpGet]
        public ActionResult Comprar(int? id)
        {
            Filme filme = db.Filmes.Find(id);
            CompraViewModel cvm = new CompraViewModel
            {
                FilmeElegido = filme,
                SalaSeleccionada = filme.Salas.ToArray()[0]
            };
            return View(cvm);
        }

        // POST: Compra/Comprar
        [HttpPost]
        public ActionResult Comprar(CompraViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                foreach (var asiento in cvm.Asientos)
                {
                    Entrada entrada = new Entrada
                    {
                        Butaca = asiento,
                        Filme = cvm.FilmeElegido,
                        HoraCompra = DateTime.Now,
                        Horario = cvm.Horario,
                        Precio = cvm.Precio,
                        Sala = cvm.SalaSeleccionada.SalaID,
                    };
                    if (cvm.EsSocio)
                    {
                        entrada.Socio = db.Socios.Find(cvm.IdSocio);
                        entrada.Socio.Puntos -= 20;
                    }
                    db.Entradas.Add(entrada);
                }
            }
            return View(cvm);
        }
    }
}