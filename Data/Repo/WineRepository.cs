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
        

    }
}
