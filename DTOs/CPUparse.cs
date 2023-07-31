﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ParserForMyApp.DTOs
{
    public class CPU
    {
        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public string? Hherz { get; set; }

        public sbyte Core { get; set; }

        public sbyte Streams { get; set; }

        public string? Socket { get; set; }
        public string Mass { get; set; }

        public decimal Price { get; set; }

    }
}
