using Dtos;
using Microsoft.AspNetCore.Mvc;
using Service;

    


namespace WineAppliaction_Git.Controllers.Wine
{
    [ApiController]
    [Route("api/wines")]
    public class WineController : Controller
    {
        private readonly IWineService _service;
        public WineController(IWineService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult RegisterWine([FromBody] WineDto wineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.CreateWine(wineDto);
            return Ok("Vino registrado correctamente.");

        }
        [HttpPut("{id}/stock")]
        public IActionResult UpdateStock(int id, [FromBody] int newStock)
        {
            try
            {
                _service.UpdateWineStock(id, newStock);
                return Ok("Stock actualizado exitosamente.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet]

        public IActionResult GetWines()
        {

            return Ok(_service.GetAllWines());

        }

        [HttpGet("{variety}")]
        public IActionResult GetWinesByVariety([FromRoute]string variety)
        {
            var wines = _service.GetWinesByVariety(variety);

            if (!wines.Any())
            {
                return NotFound($"No hay vinos disponibles de la variedad: {variety}");
            }

            return Ok(wines);
        }
    }
}

