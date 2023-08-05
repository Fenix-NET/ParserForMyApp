﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserForMyApp.Models
{
    public class Ram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public ushort Memory { get; set; }
        public byte Nmodule { get; set; }
        public string Ddr { get; set; }
        public string Mass { get; set; }
        public decimal Price { get; set; }
    }
}
