using Microsoft.AspNetCore.Mvc;
using WebApiEntityFramework.Models;
using WebApiEntityFramework.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticulosService _articulosService;
        public ArticulosController(IArticulosService articulosService)
        {
            _articulosService = articulosService;
        }

        // GET: api/<ArticulosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var articulos = await _articulosService.GetAllAsync();
                var articulosActivos = articulos.Where(a => a.Activo == true).ToList();
                return Ok(articulosActivos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }


        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var articulo = await _articulosService.GetByIdAsync(id);
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Articulo articulo)
        {
            try
            {
                await _articulosService.AddAsync(articulo);
                return Ok(articulo);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

                
            }
        }

        // PUT api/<ArticulosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Articulo articulo)
        {
            try
            {
                if (id != articulo.IdArticulo)
                {
                    return BadRequest("El ID del artículo no coincide con el ID de la URL.");
                }
                await _articulosService.UpdateAsync(articulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error: {ex.Message}");

               
            }
           

        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var articuloSeleccionado = await _articulosService.GetByIdAsync(id);
                if (articuloSeleccionado == null)
                {
                    return NotFound($"Artículo con ID {id} no encontrado.");
                }
                articuloSeleccionado.Activo = false;

                await _articulosService.UpdateAsync(articuloSeleccionado);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            

        }
    }
}
