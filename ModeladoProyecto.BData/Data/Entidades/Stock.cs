using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ModeladoProyecto.BData.Data.Entidades
    {
    [Index(nameof(CodStock), Name = "CodStock_UQ", IsUnique = true)]
    public class Stock
        {

        [Required(ErrorMessage = "El Código del producto es obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 3 caracteres en el codigo del producto")]
        public string CodStock { get; set;}
   
        public int Id { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el producto obligatorio")]
        [MaxLength(30, ErrorMessage = "Solo se aceptan hasta 30 caracteres en el producto")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el producto obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 30 caracteres en la cantidad")]
        public int Cantidad { get; set; }

        }
    }
