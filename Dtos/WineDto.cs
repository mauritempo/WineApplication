﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class WineDto
    {
        public required string Name { get; set; }
        public required string Variety { get; set; }

        public int Year { get; set; }
        public string Region { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
