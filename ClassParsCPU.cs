﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;

namespace ParserForMyApp
{
    public class ClassParsCPU : BaseParseClass
    {

        public async Task StartParsCPU(ParserContext _context)
        {
            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга CPU");
            

            foreach (string link in listref)
            {
                CPU _cpu = new();
                using var doc = GetPage(link);

                _cpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _cpu.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _cpu.Hherz = doc.QuerySelector(hherzSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _cpu.Core = sbyte.Parse(doc.QuerySelector(coreSelector)?.FirstChild.TextContent); }
                catch { _cpu.Core = 0; }

                try { _cpu.Streams = sbyte.Parse(doc.QuerySelector(streamsSelector)?.FirstChild.TextContent); }
                catch { _cpu.Streams = 0; }

                _cpu.Socket = doc.QuerySelector(socketSelector).FirstChild?.TextContent ?? "n/a";

                _cpu.Mass = doc.QuerySelector(massSelector).FirstChild?.TextContent ?? "n/a";

                try { _cpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _cpu.Price = 0; }
                Console.WriteLine(_cpu.Manufacturer);
                Console.WriteLine(_cpu.Model);
                Console.WriteLine(_cpu.Hherz);
                Console.WriteLine(_cpu.Core);
                Console.WriteLine(_cpu.Streams);
                Console.WriteLine(_cpu.Socket);
                Console.WriteLine(_cpu.Mass);
                Console.WriteLine(_cpu.Price);
                Console.WriteLine(new string('.', 80));

                _context.CPUs.Add(_cpu);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (CPUparse cpu in _cpus)
            //{
            //    Console.WriteLine(cpu.Manufacturer);
            //    Console.WriteLine(cpu.Model);
            //    Console.WriteLine(cpu.Hherz);
            //    Console.WriteLine(cpu.Socket);
            //    Console.WriteLine(cpu.Price);
            //    Console.WriteLine(new string('.', 80));
            //}



        }



    }
}