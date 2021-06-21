using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Cine.Models;
using Cine.Data;
using Cine.DAL;

namespace Cine.ViewModels
{
    public class CompraViewModel
    {
        /* Película */
        public Filme FilmeElegido { get; set; }


        /* Tickets */
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Es necesario comprar al menos una entrada.")]
        [DisplayName("Cantidad de Entradas")]
        public int Cantidad { get; set; }

        public int[] Asientos { get; set; }

        [DisplayName("Sala")]
        public Sala SalaSeleccionada { get; set; }
        public Tuple<Sala[], int[], int[][]> SalasInfo { get; set; }

        [DisplayName("Horario")]
        public DateTime Horario { get; set; }

        public int Precio
        {
            get => (DiscountType == TipoDescuento.Ninguno) ? 20 : 18;
        }

        public float PrecioEnDolares
        {
            get => (float)Precio / 10;
        }


        /* Formas de Pago */
        [Required]
        [DisplayName("Pagar con Puntos de Socio")]
        public bool EsSocio { get; set; }


        [DisplayName("Id de Socio")]
        [SocioIdValidation(ErrorMessage = "El ID de Socio provisto no fue encontrado")]
        [PaymentValidation(ErrorMessage = "La cantidad de puntos acumulados no es suficiente para realizar el pago")]
        public int IdSocio { get; set; }


        [DisplayName("Tarjeta de Crédito")]
        [DataType(DataType.CreditCard)]
        public int TarjetaCredito { get; set; }


        [DisplayName("Tipo de Descuento")]
        public TipoDescuento DiscountType { get; set; }
    }

    public class PaymentValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CompraViewModel)validationContext.ObjectInstance;
            CineContext db = new CineContext();
            string error_msg = "La cantidad de puntos acumulados no es suficiente para realizar el pago";

            return (db.Socios.Find(model.IdSocio).Puntos >= model.Precio)
                ? ValidationResult.Success
                : new ValidationResult(error_msg);
        }
    }

    public class SocioIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CompraViewModel)validationContext.ObjectInstance;
            CineContext db = new CineContext();

            if (model.EsSocio && db.Socios.Find(model.IdSocio) != null)
                return ValidationResult.Success;
            else
                return new ValidationResult("El ID de Socio provisto no fue encontrado");

        }
    }

    public class AdditionalValidation
    {
        public static ValidationResult ValidateSocioId(int id)
        {
            CineContext db = new CineContext();
            Socio socio = db.Socios.Find(id);

            if (socio == null)
                return new ValidationResult("El ID de Socio provisto no fue encontrado");
            else
                return ValidationResult.Success;
        }
    }
}