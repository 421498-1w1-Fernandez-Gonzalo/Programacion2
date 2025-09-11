using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;
        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }
        // GET: api/<ArticuloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var articulos = _articuloService.GetAll();
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var articulo = _articuloService.GetById(id);
                if (articulo == null)
                {
                    return NotFound();
                }
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("El artículo no puede ser nulo.");
                }
                _articuloService.Save(articulo);
                return Ok(articulo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("El artículo no puede ser nulo.");
                }

                if (id != articulo.Codigo)
                {
                    return BadRequest("El ID de la URL no coincide con el del artículo.");
                }

                var existingArticulo = _articuloService.GetById(id);
                if (existingArticulo == null)
                {
                    return NotFound();
                }

                _articuloService.Update(articulo);

                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _articuloService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
