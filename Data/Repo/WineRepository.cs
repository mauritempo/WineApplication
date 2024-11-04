using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class WineRepository
    {
        private readonly WineContext _context;
        public WineRepository(WineContext context)
        {
            _context = context;
        }



        public int AddWine(Wine wine)
        {
            if (wine == null)
            {
                throw new ArgumentNullException(nameof(wine));
            }

            _context.Wines.Add(wine);            // Agregar a una lista, podrías conectarlo con una base de datos
            _context.SaveChanges();
            return wine.Id;
        }

        public List<Wine> GetWines() // Método para obtener todos los vinos
        {
            return _context.Wines.Include(w => w.User).ThenInclude(w => w.incluir).ToList();
            //usar includeTHeninclude traer parametros sin dto 
            return _context.Wines.Include(w => w.User).Include(W=> W.Catas).ToList();
            //INCLUDE DATOS DE MASM8
        }


        // Método para añadir Stock a un vino específico
        public void ChangeStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0");
            //Stock += amount;
        }
        public void Update(Wine wine)
        {
            _context.Wines.Update(wine);
            _context.SaveChanges();
        }
        public Wine GetById(int id)
        {
            return _context.Wines.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Wine> GetWinesByVarietyAndYear(string variety, int year)
        {
            // La consulta LINQ para obtener los vinos según la variedad y año de cosecha
            return _context.Wines.Where(wine => wine.Variety == variety && wine.Year == year)
                .Take(5) // Tomar solo los primeros 5 elementos
                .ToList();


        }

        public IEnumerable<Wine> GetWinesByStockAndRegion(string region)
        {
            return _context.Wines.Where(wine => wine.Stock > 10 && wine.Region == region)
                .ToList();

        }
        public IEnumerable<dynamic> GetWineNamesByRegionWithStockGreaterThan10(string region)
        {
            return _context.Wines.Where(wine => wine.Stock > 10 && wine.Region == region)
                .Select(wine => new { wine.Name, wine.Stock })  // Solo proyectamos `Name` y `Stock`
                .ToList();

        }
        public IEnumerable<dynamic> GetTop5WinesByVarietyAndYear(string variety, int year)
        {
            return _context.Wines.Where(wine => wine.Variety == variety && wine.Year == year)
                .OrderBy(wine => wine.Name) // Por ejemplo, ordenar por `Name`
                .Take(5)
                .Select(wine => new { wine.Name, wine.Year, wine.Variety, wine.Stock })
                .ToList();

        }





    }
}
