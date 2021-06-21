using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cine.DAL;
using Cine.Data;
using Cine.ViewModels;

namespace Cine.Controllers
{
    public class EstadisticasController : Controller
    {
        private CineContext db = new CineContext();

        // GET: Estadisticas
        public ActionResult Index()
        {
            var summary = new Dictionary<string, int>()
            {
                { "Día", db.Entradas.Count(s => s.HoraCompra == DateTime.Today) },
                { "Mes", db.Entradas.Count(s => s.HoraCompra.Year == DateTime.Today.Year && s.HoraCompra.Month == DateTime.Today.Month) },
                { "Año", db.Entradas.Count(s => s.HoraCompra.Year == DateTime.Today.Year) },
                { "Total", db.Entradas.Count() }
            };
            return View(summary);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(EstadisticasFormModel form)
        {
            var entradas = from s in db.Entradas
                           select s;
            var filmes = from s in db.Filmes
                         select s;
            CriterioEst criterio = form.Criterio;
            EstadisticasShowModel showData = new EstadisticasShowModel
            {
                criterio = criterio
            };

            if (criterio == CriterioEst.Periodo) // periodo de fechas
            {
                int ventasPorPeriodo = entradas.Count(
                    s => s.HoraCompra >= form.Desde && s.HoraCompra <= form.Hasta);
                showData.data = new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(
                        string.Format("{0} - {1}", form.Desde, form.Hasta),
                        ventasPorPeriodo)
                };
            }

            if (criterio == CriterioEst.Filme) // consultar por filme
            {
                var ventasPorFilme = filmes.ToDictionary(
                                               f => f.Nombre,
                                               f => entradas.Count(e => e.Filme.FilmeID == f.FilmeID))
                                           .OrderByDescending(pair => pair.Value);
                showData.data = ventasPorFilme;
            }

            if (criterio == CriterioEst.Actor) // consultar por actor del filme
            {
                var ventasPorActor = filmes.Select(f => f.actor)
                                           .ToHashSet().ToDictionary(
                                               a => a,
                                               a => entradas.Count(e => e.Filme.actor == a))
                                           .OrderByDescending(pair => pair.Value);
                showData.data = ventasPorActor;
            }

            if (criterio == CriterioEst.Genero) // consultar por genero del filme
            {
                var ventasPorGenero = filmes.Select(f => f.Genero)
                                            .ToHashSet().ToDictionary(
                                                g => g,
                                                g => entradas.Count(e => e.Filme.Genero == g))
                                            .OrderByDescending(pair => pair.Value);
                showData.data = ventasPorGenero;
            }

            if (criterio == CriterioEst.Rating) // consultar por rating del filme
            {
                var ventasPorRating = new Dictionary<string, int>();
                for (int i = 1; i <= 10; i++)
                {
                    ventasPorRating.Add(
                        string.Format("{0}", i),
                        filmes.Count(f => (int)entradas.Where(e => e.Filme == f)
                                                       .Select(e => e.Calificacion)
                                                       .Average() == i));
                }
                showData.data = ventasPorRating.Reverse();
            }

            if (criterio == CriterioEst.Nacionalidad) // comparacion entre cubano y extranjero
            {
                int cubanas = filmes.Count(f => f.Pais == "Cuba"),
                    extranjeras = filmes.Count(f => f.Pais != "Cuba");
                var ventasPorNacionalidad = new Dictionary<string, int>
                {
                    { "Cubanas", cubanas },
                    { "Extranjeras", extranjeras }
                };
                showData.data = ventasPorNacionalidad;
            }
            return View("Show", showData);
        }
    }
}
