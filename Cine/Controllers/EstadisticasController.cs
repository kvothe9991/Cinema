using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cine.DAL;

namespace Cine.Controllers
{
    public enum CriterioEst
    {
        Dia, Mes, Anho, Periodo, FilmeE, Actor, Genero, Rating, Comp
    }
    public class EstadisticasController : Controller
    {
        private CineContext db = new CineContext();
        
         // GET: Estadisticas
         public ActionResult Index(CriterioEst criterio, DateTime ini, DateTime fini, Filme filme, string filtro, int rating)
        {
            var entradas = from s in db.Entradas
                           select s;
            var filmes = from s in db.Filmes
                         select s;

            if (criterio == CriterioEst.Dia) //consultar por dia
            {
                entradas = entradas.Where(s => s.HoraCompra == DateTime.Today);
                return View(entradas);
            }

            if (criterio == CriterioEst.Mes) //consultar por mes
            {
                entradas = entradas.Where(s => s.HoraCompra.Month == DateTime.Today.Month);
                return View(entradas);
            }

            if (criterio == CriterioEst.Anho) //consultar por anho
            {
                entradas = entradas.Where(s => s.HoraCompra.Year == DateTime.Today.Year);
                return View(entradas);
            }

            if (criterio == CriterioEst.Periodo) // periodo de fechas
            {
                entradas = entradas.Where(s => s.HoraCompra >= ini && s.HoraCompra <= fini);
                return View(entradas);
            }

            if (criterio == CriterioEst.FilmeE) // consultar por filme
            {
                entradas = entradas.Where(s => s.Filme == filme);
                return View(entradas);
            }

            if (criterio == CriterioEst.Actor) // consultar por actor del filme
            {
                filmes = filmes.Where(s => s.actores.Contains(filtro));
                return View(filmes);
            }

            if (criterio == CriterioEst.Genero) // consultar por genero del filme
            {
                filmes = filmes.Where(s => s.Genero == filtro);
                return View(filmes);
            }

            if (criterio == CriterioEst.Rating) // consultar por rating del filme
            {
                filmes = filmes.Where(s => s.Calificacion == rating);
                return View(filmes);
            }
            if (criterio == CriterioEst.Comp) // comparacion entre cubano y extranjero
            {
                return View(new Tuple<ICollection<Filme>, ICollection<Filme>>((ICollection<Filme>)filmes.Where(s => s.Pais == "Cuba"), (ICollection<Filme>)filmes.Where(s => s.Pais != "Cuba")));
            }

            return View(/* un object con las estadisticas */);
        }
    }
}
