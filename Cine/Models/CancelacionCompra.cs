using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;

namespace Cine.Models
{
    public class CancelacionCompra
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Id de Compra")]
        public int Id { get; set; }
        public bool Cancelable { get; set; }
        public bool Encontrado { get; set; }
    }
}