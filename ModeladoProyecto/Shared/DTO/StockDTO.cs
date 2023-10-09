using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeladoProyecto.Shared.DTO
    {
    public class StockDTO
        {
        public int Id { get; set; }  //ver que hacer con esto

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el nombre del producto")]
        public string Producto {get; set;}


		[Required(ErrorMessage = "El nombre del producto es obligatorio")]
		[MaxLength(4, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el nombre del producto")]
		public int Cantidad { get; set;}


		[Required(ErrorMessage = "El codigo de stock es obligatorio")]
		public string CodStock { get; set;} 




        }
    }
