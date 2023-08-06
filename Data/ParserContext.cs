using Microsoft.EntityFrameworkCore;
using ParserForMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserForMyApp.Data
{
    public class ParserContext : DbContext
    {
        public string DbPath { get; } = "server=localhost;username=postgres;database=PCBuilder;Password=959595";

        public ParserContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(DbPath);
        public DbSet<Case> Case { get; set; }
        public DbSet<Cpu> Cpu { get; set; }
        public DbSet<Gpu> Gpu { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Psu> Psu { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Ssd> Ssd { get; set; }
        public DbSet<Hdd> Hdd { get; set; }
        //public DbSet<ImageCase> ImageCases { get; set; }
        //public DbSet<ImageCpu> ImageCpus { get; set; }
        //public DbSet<ImageGpu> ImageGpus { get; set; }
        //public DbSet<ImageMotherboard> ImageMotherboards { get; set; }
        //public DbSet<ImagePsu> ImagePsus { get; set; }
        //public DbSet<ImageRam> ImageRams { get; set; }

    }
}
