using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeladoProyecto.BData.Data.Entidades;

namespace ModeladoProyecto.BData.Data
{ 
    public class Context : DbContext
    {

        public Context(DbContextOptions options) : base(options)
            {
            }

        public DbSet<Stock> stock {get; set;}

        

    }
}
