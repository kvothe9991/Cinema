using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class Horario
    {
        public int HorarioID { get; set; }
        public int HH { get; set; }
        public int MM { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}