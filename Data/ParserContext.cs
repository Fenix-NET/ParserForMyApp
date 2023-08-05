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
        public DbSet<Case> Cases { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Psu> Psus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<ImageCase> ImageCases { get; set; }
        public DbSet<ImageCpu> ImageCpus { get; set; }
        public DbSet<ImageGpu> ImageGpus { get; set; }
        public DbSet<ImageMotherboard> ImageMotherboards { get; set; }
        public DbSet<ImagePsu> ImagePsus { get; set; }
        public DbSet<ImageRam> ImageRams { get; set; }

    }
}
