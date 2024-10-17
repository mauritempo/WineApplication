using Data.Entities;
using Data.Repo;
using Dtos;
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
        public Wine CreateWine(WineDto wineDto)
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
            return wine;
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
        public Wine UpdateWineStock(int id, int newStock)
        {
            var wine = _wineRepository.GetById(id);
            if (wine == null)
            {
                throw new KeyNotFoundException("El vino con el Id especificado no fue encontrado.");
            }

            if (newStock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }

            wine.Stock = newStock;
            _wineRepository.Update(wine);
            return wine;
        }
        public List<Wine> GetWinesByVariety(string variety)
        {
            return _wineRepository.GetWines()
                   .Where(wine => wine.Variety.Equals(variety, StringComparison.OrdinalIgnoreCase)
                   && wine.Stock > 0).ToList();
        }

    }
}
