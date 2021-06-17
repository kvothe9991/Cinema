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
using Cine.Data;

namespace Cine.Controllers
{

    public class FilmeController : Controller
    {
        private CineContext db = new CineContext();

        // GET: Filme
        public ActionResult Index()
        {
            return View(db.Filmes.ToList());
        }

        // GET: Filme/Details/5
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

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeID,Disponible,Calificacion")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Filme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeID,Disponible,Calificacion")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Top()
        {
            var filmes = from s in db.Filmes
                           select s;

            filmes = filmes.Where(s => s.Disponible == true);

            if(CriterioActual.Criterio == Criterio.MasVistas) //las + vistas
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
                
                return View(vistas.Take(10));
            }
            else if(CriterioActual.Criterio == Criterio.MasGustadas) //las + gustadas
            {
                var entradas = from s in db.Entradas
                               select s;

                entradas = entradas.Where(s => filmes.Contains(s.Filme));
                Dictionary<int, List <int>> cal = new Dictionary<int, List <int>>(); //<FilmeId, calificaciones>;

                foreach (var e in entradas)
                {
                    if (!cal.ContainsKey(e.FilmeID))
                        cal.Add(e.FilmeID, new List<int>());
                    cal[e.FilmeID].Append(e.Calificacion);
                }

                Dictionary<int, int> gustadas = new Dictionary<int, int>(); //<FilmeId, calificacion>;

                foreach(var f in cal)
                {
                    gustadas.Add(f.Key, f.Value.Sum() / f.Value.Count);
                }
                gustadas.OrderBy(s => s.Value);
                gustadas.Reverse();

                return View(gustadas.Take(10));

            }
            else if(CriterioActual.Criterio == Criterio.InteresEconomico) // intereses economicos
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
                return View(vistas.Take(10));
            }
            else if(CriterioActual.Criterio == Criterio.Aleatorio) //aleatorio
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

                return View(list.Take(10));
            }
            
            return View(new Tuple<ICollection<Filme>, Criterio>((ICollection<Filme>)filmes, CriterioActual.Criterio));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
