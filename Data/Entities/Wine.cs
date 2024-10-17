using Data.Entities;
using Data.Entities.Catas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // El nombre del vino, requerido
        public string Name { get; set; } = string.Empty;

        // Variedad del vino (ej: Cabernet Sauvignon)
        public string Variety { get; set; } = string.Empty;
        [Required]

        // Año de cosecha, debe ser un valor válido
        public int Year { get; set; }

        // Región de origen (ej: Mendoza, La Rioja)
        public string Region { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int Stock {  get; set; }

        public List<Cata> Catas { get; set; } = new List<Cata>();

    }
}

}

