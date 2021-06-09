using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class CancelacionCompraModel
    {
        public int Id { get; set; }
        public bool Cancelable { get; set; }
        public bool Encontrado { get; set; }
    }
}