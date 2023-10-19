using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ModeladoProyecto.BData.Data.Entidades
    {
    public class Stock
        {

		public int id { get; set; }

		[Required(ErrorMessage = "El Código del producto es obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 3 caracteres en el codigo del producto")]
        public string CodStock { get; set;}

        [Required(ErrorMessage = "Es necesario introducir el producto obligatorio")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el producto")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el producto obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 digitos en la cantidad")]
        public string Cantidad { get; set; }

        //conexion dto
        //public int StockId { get; set; }

        }
    }
