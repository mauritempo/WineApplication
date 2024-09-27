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
        List<Wine> winesInventory = new List<Wine>
        {
            new Wine
            {
                Id = 1,
                Name = "Cabernet Sauvignon",
                Variety = "Cabernet Sauvignon",
                Year = 2020,
                Region = "Mendoza",
                CreatedAt = DateTime.UtcNow,
                Stock = 150 // Usando el setter público para modificar _stock
            },
            new Wine
            {
                Id = 2,
                Name = "Malbec",
                Variety = "Malbec",
                Year = 2019,
                Region = "La Rioja",
                CreatedAt = DateTime.UtcNow,
                Stock = 200
            },
            new Wine
            {
                Id = 3,
                Name = "Merlot",
                Variety = "Merlot",
                Year = 2018,
                Region = "San Juan",
                CreatedAt = DateTime.UtcNow,
                Stock = 100
            },
            new Wine
            {
                Id = 4,
                Name = "Syrah",
                Variety = "Syrah",
                Year = 2021,
                Region = "Neuquén",
                CreatedAt = DateTime.UtcNow,
                Stock = 80
            },
            new Wine
            {
                Id = 5,
                Name = "Chardonnay",
                Variety = "Chardonnay",
                Year = 2022,
                Region = "Tucumán",
                CreatedAt = DateTime.UtcNow,
                Stock = 60
            }
        };



        public void AddWine(Wine wine)
        {
            if (wine == null)
            {
                throw new ArgumentNullException(nameof(wine));
            }

            winesInventory.Add(wine); // Agregar a una lista, podrías conectarlo con una base de datos
        }

        public List<Wine> GetWines() // Método para obtener todos los vinos
        {
            return winesInventory;
        }


        // Método para añadir stock a un vino específico
        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");
            //Stock += amount;
        }

        // Método para obtener todos los vinos (opcional)
        public List<Wine> GetAllWines()
        {
            return winesInventory;
        }
    }
}
