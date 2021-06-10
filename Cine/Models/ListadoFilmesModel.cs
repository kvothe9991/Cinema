using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class ListadoFilmesModel
    {
        public ICollection<Filme> Filmes { get; set; }
    }
}