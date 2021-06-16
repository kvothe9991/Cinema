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
        public string actor { get; set; }
        
        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection <Sala> Salas { get; set; }
        public virtual ICollection<Socio> Socios { get; set; }
    }
}
