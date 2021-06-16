using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cine.DAL;
using Cine.Models;

namespace Cine.Controllers
{
    public enum CriterioEst
    {
        Actor, Filme, Genero, Nacionalidad, Periodo, Rating
    }
    public class EstadisticasController : Controller
    {
        private CineContext db = new CineContext();

        // GET: Estadisticas
        public ActionResult Index()
        {
            var summary = new Dictionary<string, int>()
            {
                { "Día", db.Entradas.Count(s => s.HoraCompra == DateTime.Today) },
                { "Mes", db.Entradas.Count(s => s.HoraCompra.Month == DateTime.Today.Month) },
                { "Año", db.Entradas.Count(s => s.HoraCompra.Year == DateTime.Today.Year) },
                { "Total", db.Entradas.Count() }
            };
            return View(summary);
        }

        public ActionResult Details(CriterioEst criterio)
        {
            var entradas = from s in db.Entradas
                           select s;
            var filmes = from s in db.Filmes
                         select s;
            /*
            if (criterio == CriterioEst.Periodo) // periodo de fechas
            {
                entradas = entradas.Where(s => s.HoraCompra >= ini && s.HoraCompra <= fini);
                return View(entradas);
            }
            */

            if (criterio == CriterioEst.Filme) // consultar por filme
            {
                var ventasPorFilme = filmes.ToDictionary(
                                               f => f.Nombre,
                                               f => entradas.Count(e => e.Filme == f))
                                           .OrderByDescending(pair => pair.Value);
                return View(ventasPorFilme);
            }

            if (criterio == CriterioEst.Actor) // consultar por actor del filme
            {
                var ventasPorActor = filmes.SelectMany(f => f.actores)
                                           .ToHashSet().ToDictionary(
                                               a => a,
                                               a => entradas.Count(e => e.Filme.actores.Contains(a)))
                                           .OrderByDescending(pair => pair.Value);
                return View(ventasPorActor);
            }

            if (criterio == CriterioEst.Genero) // consultar por genero del filme
            {
                var ventasPorGenero = filmes.Select(f => f.Genero)
                                            .ToHashSet().ToDictionary(
                                                g => g,
                                                g => entradas.Count(e => e.Filme.Genero == g))
                                            .OrderByDescending(pair => pair.Value);
                return View(ventasPorGenero);
            }

            if (criterio == CriterioEst.Rating) // consultar por rating del filme
            {
                var ventasPorRating = new Dictionary<string, int>();
                for (int i = 0; i <= 8; i+=2)
                {
                    ventasPorRating.Add(
                        string.Format("{0}-{1}", i, i+2),
                        entradas.Count(e => i <= e.Filme.Calificacion && e.Filme.Calificacion < i+2)
                    );
                }
                return View(ventasPorRating);
            }

            if (criterio == CriterioEst.Nacionalidad) // comparacion entre cubano y extranjero
            {
                int cubanas = filmes.Count(f => f.Pais == "Cuba"),
                    extranjeras = filmes.Count(f => f.Pais != "Cuba");
                return View(new Tuple<int, int>(cubanas, extranjeras));
            }

            return View(/* un object con las estadisticas */);
        }
    }
}
