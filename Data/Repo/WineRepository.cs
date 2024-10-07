using Data.Entities;
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
            return _context.Wines.ToList();
        }


        // Método para añadir stock a un vino específico
        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0");
            //Stock += amount;
        }

        
    }
}
