using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cine.DAL;
using System.Data.Entity;

namespace Cine.Models
{
    public class Sala
    {
        private CineContext db = new CineContext();
        public int SalaID { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
        public int Asientos { get; set; }
        public int[] AsientosOcupados
        {
            get
            {
                return db.Entradas.Where(e => e.Sala == this.SalaID).Select(e => e.Butaca).ToArray();
            }
        }
        public override string ToString()
        {
            return string.Format("Sala {0}", SalaID);
        }
    }
}