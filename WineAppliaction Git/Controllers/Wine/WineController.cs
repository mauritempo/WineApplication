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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.CreateWine(wineDto);
            return Ok("Vino registrado correctamente.");
        
    }

    [HttpGet]

    public IActionResult GetWine(IWineService wine)
    {
        
            return Ok(_service.GetAllWines());

    }

}
