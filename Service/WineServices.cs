using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WineServices : IWineService
    {
        private readonly WineRepository _wineRepository;

        public WineServices(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;

        }
        public void CreateWine(WineDto wineDto)
        {

            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock,

            };

            // Guardar el vino en el repositorio
            _wineRepository.AddWine(wine);
        }

        public List<WineDto> GetAllWines()
        {
            var wines = _wineRepository.GetWines(); // Llamada al repositorio

            // Mapear las entidades Wine a WineDto
            return wines.Select(w => new WineDto
            {

                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }
    }
}
