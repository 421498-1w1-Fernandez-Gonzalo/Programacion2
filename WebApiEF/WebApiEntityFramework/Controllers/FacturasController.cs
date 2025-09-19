using Microsoft.AspNetCore.Mvc;
using WebApiEntityFramework.DTO;
using WebApiEntityFramework.Models;
using WebApiEntityFramework.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IFacturasService _facturasService;
        public FacturasController(IFacturasService facturasService)
        {
            _facturasService = facturasService;
        }
        // GET: api/<FacturasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var facturasDto = new List<FacturasDTO>();
                var facturas = await _facturasService.GetAllAsync();
                foreach (var item in facturas)
                {
                    var factura = FacturasDTO.FromModel(item);
                    facturasDto.Add(factura);
                }
                return Ok(facturasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
               
            }  
        }

        // GET api/<FacturasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var factura = await _facturasService.GetByIdAsync(id);
                if (factura == null)
                    return NotFound();
               var facturaDTO = FacturasDTO.FromModel(factura);

                return Ok(facturaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<FacturasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturasDTO facturaDTO)
        {
            try
            {
                var facturaParaAgregar= FacturasDTO.ToModel(facturaDTO);
                await _facturasService.AddAsync(facturaParaAgregar);


                return Ok(facturaParaAgregar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT api/<FacturasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FacturasDTO facturaDTO)
        {
            try
            {
                var facturaParaActualizar = FacturasDTO.ToModel(facturaDTO);
                await _facturasService.UpdateAsync(facturaParaActualizar);
                return Ok(facturaParaActualizar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var facturaSeleccionada = await _facturasService.GetByIdAsync(id);
                if (facturaSeleccionada == null)
                {
                    return NotFound();
                }else
                {
                    facturaSeleccionada.Activo = false;
                    await _facturasService.UpdateAsync(facturaSeleccionada);
                    return Ok(facturaSeleccionada);
                }
                

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
