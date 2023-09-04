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
        public async Task<ActionResult<Stock>> Get(int Id)
            {
            var existe = await context.stock.AnyAsync(x => x.Id == Id);
            if (!existe)
                {
                return NotFound($"El producto {Id} no existe");
                }
            return await context.stock.FirstOrDefaultAsync(x => x.Id == Id);
            }

        [HttpPost]
        public async Task<ActionResult<int>> Post(StockDTO stock)
            {
            var entidad = await context.stock.FirstOrDefaultAsync(x => x.Id == stock.Id);

            if (entidad != null)
                {
                return BadRequest("Ya existe un producto con ese Id");
                }
            try
                {
                Stock x = new Stock();
                x.Id = stock.Id;
                x.Producto = stock.Producto;
                x.Cantidad = stock.Cantidad;

                context.stock.Add(x);
                await context.SaveChangesAsync();
                return x.Id;

                }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async Task<IActionResult> Editar(StockDTO stockDTO, int Id)
            {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbStock = await context.stock.FirstOrDefaultAsync(e => e.Id == Id);
                if (dbStock != null)
                    {
                    dbStock.Id = stockDTO.Id;
                    dbStock.Producto = stockDTO.Producto;
                    dbStock.Cantidad = stockDTO.Cantidad;
                    await context.SaveChangesAsync();
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbStock.Id;

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
        public async Task<ActionResult> Delete(int Id)
            {
            var existe = await context.stock.AnyAsync(x => x.Id == Id);
            if (!existe)
                {
                return NotFound($"El producto de id={Id} no existe");
                }
            Stock juan = new Stock();
            juan.Id = Id;

            context.Remove(juan);

            await context.SaveChangesAsync();

            return Ok();
            }












        }
}   

