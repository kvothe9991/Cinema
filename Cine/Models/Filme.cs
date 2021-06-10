using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class Filme
    {
        public int FilmeID { get; set; }
        public bool Disponible { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public List<string> actores { get; set; }
        public int Calificacion { get; set; }
        public List<DateTime> Horarios { get; set; }
        public List<int> Salas { get; set; }

        public ICollection<Socio> Socios { get; set; }
    }
}