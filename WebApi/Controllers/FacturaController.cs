using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.Domain;
using _421498__1w1_FernandezGonzalo_Programacion2_Entregable.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }
        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var facturas = _facturaService.GetAll();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var factura = _facturaService.GetById(id);
                if (factura == null)
                {
                    return NotFound();
                }
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            try
            {
                _facturaService.Save(factura);
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Factura factura)
        {
            try
            {
                if (factura == null || factura.Codigo != id)
                {
                    return BadRequest("El ID de la factura no coincide.");
                }
                var existingFactura = _facturaService.GetById(id);
                if (existingFactura == null)
                {
                    return NotFound();
                }
                _facturaService.Update(factura);
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingFactura = _facturaService.GetById(id);
                if (existingFactura == null)
                {
                    return NotFound();
                }
                _facturaService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
