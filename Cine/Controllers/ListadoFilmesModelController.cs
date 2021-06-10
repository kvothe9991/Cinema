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

        public ActionResult Index(int criterio = 0)
        {
            var filmes = from s in db.Filmes
                           select s;

            filmes = filmes.Where(s => s.Disponible == true);

            if(criterio > 0)
            {
                if(criterio == 1) //las + vistas
                {
                    var entradas = from s in db.Entradas
                                   select s;
                    entradas = entradas.Where(s => filmes.Contains(s.Filme));

                    Dictionary<int, int> vistas = new Dictionary<int, int>(); //<FilmeId, cantidad de veces vista>;
                    foreach (var e in entradas)
                    {
                        if (!vistas.ContainsKey(e.FilmeID))
                            vistas.Add(e.FilmeID, 0);
                        vistas[e.FilmeID]++;
                    }
                    vistas.OrderBy(s => s.Value);
                    vistas.Reverse();
                    filmes = (IQueryable<Filme>) new List<Filme>();
                    foreach(var v in vistas.Take(10))
                    {
                        filmes.Append(db.Filmes.Find(v.Key));
                    }
                }
                else if(criterio == 2) //las + gustadas
                {
                    filmes = filmes.OrderBy(s => s.Calificacion);
                }
                else if(criterio == 3) // intereses economicos
                {
                    var entradas = from s in db.Entradas
                                   select s;
                    entradas = entradas.Where(s => filmes.Contains(s.Filme));

                    Dictionary<int, int> vistas = new Dictionary<int, int>(); //<FilmeId, ganancia acumulada>;
                    foreach (var e in entradas)
                    {
                        if (!vistas.ContainsKey(e.FilmeID))
                            vistas.Add(e.FilmeID, 0);
                        vistas[e.FilmeID] = vistas[e.FilmeID] + e.Precio;
                    }
                    vistas.OrderBy(s => s.Value);
                    vistas.Reverse();
                    filmes = (IQueryable<Filme>)new List<Filme>();
                    foreach (var v in vistas.Take(10))
                    {
                        filmes.Append(db.Filmes.Find(v.Key));
                    }
                }
                else if(criterio == 4) //aleatorio
                {
                    List<Filme> list = filmes.ToList();
                    Random r = new Random();

                    for (int i = 0; i < list.Count(); i++)
                    {
                        int rint = r.Next(i, list.Count());
                        Filme filmet = list[i];
                        list[i] = list[rint];
                        list[rint] = filmet;
                    }
                    filmes = (IQueryable<Filme>)new List<Filme>();
                    foreach (var x in list.Take(10))
                    {
                        filmes.Append(x);
                    }
                }
            }

            return View(new ListadoFilmesModel { Filmes = (ICollection<Filme>)filmes });
        }
    }
}
