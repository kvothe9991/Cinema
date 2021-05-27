using System;
using System.Collections.Generic;

namespace Cine.Models
{
    public class Socio
    {
        public int SocioID { get; set; }
        public int Puntos { get; set; }
        public string DatosPersonales { get; set; }
        public string UsuarioDescuento { get; set; }

        public ICollection<Filme> Filme { get; set; }
    }

    public class Filme
    {
        public int FilmeID { get; set; }
        public bool Disponible { get; set; }
        public int Calificacion { get; set; }
        //public List<DateTime> Horarios { get; set; }
        //public List<int> Salas { get; set; }

        public ICollection<Socio> Socio { get; set; }
    }
    public class Entrada
    {
        public int SocioID { get; set; }
        public Socio Socio { get; set; }
        public int FilmeID { get; set; }
        public Filme Filme { get; set; }

        public int Precio { get; set; }
        public DateTime HoraCompra { get; set; }
        public DateTime Horario { get; set; }
        public int Sala { get; set; }
    }
}

