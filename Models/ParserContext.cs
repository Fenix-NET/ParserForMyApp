﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserForMyApp.Models
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
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<ImageCase> ImageCases { get; set; }
        public DbSet<ImageCPU> ImageCPUs { get; set; }
        public DbSet<ImageGPU> ImageGPUs { get; set; }
        public DbSet<ImageMotherboard> ImageMotherboards { get; set; }
        public DbSet<ImagePSU> ImagePSUs { get; set; }
        public DbSet<ImageRAM> ImageRAMs { get; set; }

    }
}
