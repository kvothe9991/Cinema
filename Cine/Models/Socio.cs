using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class Socio
    {
        public int SocioID { get; set; }
        public int Puntos { get; set; }
        public string DatosPersonales { get; set; }
        public string UsuarioDescuento { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}