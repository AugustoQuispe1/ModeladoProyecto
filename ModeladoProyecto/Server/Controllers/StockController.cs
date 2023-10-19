using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ModeladoProyecto.BData;
using ModeladoProyecto.Shared;
using ModeladoProyecto.BData.Data;
using ModeladoProyecto.BData.Data.Entidades;
using ModeladoProyecto.Shared.DTO;

namespace ModeladoProyecto.Server.Controllers
    {
    [ApiController]
    [Route("api/stock")]
    public class StockController :ControllerBase
        {
        private readonly Context context;
        public StockController(Context context)
            {
            this.context = context;
            }
        [HttpGet]
        public async Task<ActionResult<List<Stock>>> Get()
            {
            return await context.stock.ToListAsync();
            }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Stock>> Get(int id)
            {
            var existe = await context.stock.AnyAsync(x => x.id == id);
            if (!existe)
                {
                return NotFound($"El producto {id} no existe");
                }
            return await context.stock.FirstOrDefaultAsync(x => x.id == id);
            }

        [HttpPost]
        public async Task<ActionResult<int>> Post(StockDTO stock)
            {
            var entidad = await context.stock.FirstOrDefaultAsync(x => x.CodStock == stock.CodStock);

            if (entidad != null)
                {
                return BadRequest("Ya existe un producto con ese Id");
                }
            try
                {
                Stock x = new Stock();
                x.CodStock = stock.CodStock;
                x.Producto = stock.Producto;
                x.Cantidad = stock.Cantidad;

                context.stock.Add(x);
                await context.SaveChangesAsync();
                return x.id;

                }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Editar(StockDTO stockDTO, int id)
            {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbStock = await context.stock.FirstOrDefaultAsync(e => e.id == id);
                if (dbStock != null)
                    {
                    dbStock.id = id;
                    //dbStock.StockId = stockDTO.StockId;
                    dbStock.Producto = stockDTO.Producto;
                    dbStock.Cantidad = stockDTO.Cantidad;
                    await context.SaveChangesAsync();
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbStock.id;

                    }
                else
                    {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto no encontrado";
                    }
                }
            catch (Exception ex)
                {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
                }
            return Ok(responseApi);
            }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.stock.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto de id={id} no existe");
            }

            context.Remove(new Stock() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }












        }
}   

