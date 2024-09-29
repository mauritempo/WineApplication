using Dtos;
using Microsoft.AspNetCore.Mvc;
using Service;

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
    public IActionResult RegisterWine([FromBody]WineDto wineDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.CreateWine(wineDto);
            return Ok("Vino registrado correctamente.");
        }
        catch (Exception ex) 
        {
            return StatusCode(500, "Error al crear el vino: " + ex.Message);
        }
        
    }

    [HttpGet]

    public IActionResult GetWine(IWineService wine)
    {
        try
        {
            return Ok(_service.GetAllWines());

        }
        catch(Exception ex) 
        {
            return StatusCode(500, "Error al obtener los vinos: " + ex.Message);
        }
        
    }




}
