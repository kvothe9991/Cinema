using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.ViewModels
{
    public class FilmeViewModel
    {
        public bool Disponible { get; set; }
        public int Calificacion { get; set; }
        public List<DateTime> Horarios { get; set; }
        public List<int> Salas { get; set; }
    }
}