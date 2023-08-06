using ParserForMyApp.DTOs;
using ParserForMyApp.Models;
using ParserForMyApp.Parser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParserForMyApp
{
    public class TestCpuParse : BaseParser
    {

        public List<Cpu> _cpus = new();
        public TestCpuParse() { }
        public async Task StartParsCpu()
        {
            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга CPU");
            var manufacturerSelector = "td#tdsa2943";
            var modelSelector = "td#tdsa2944";
            var socketSelector = "td#tdsa1307";

            foreach (string link in listref)
            {
                Cpu _cpu = new();
                using var doc = GetPage(link);

                _cpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _cpu.Model = doc.QuerySelector(modelSelector).FirstChild?.TextContent ?? "n/a";
                Console.WriteLine($"Модель : {_cpu.Model}");

                _cpu.Socket = doc.QuerySelector(socketSelector).FirstChild?.TextContent ?? "n/a";

                _cpus.Add(_cpu);
            }
            Console.WriteLine("Конец работы");
            foreach (Cpu cPUparse in _cpus)
            {
                Console.WriteLine(cPUparse.Manufacturer);
                Console.WriteLine(cPUparse.Model);
                Console.WriteLine(cPUparse.Socket);
                Console.WriteLine(new string('.', 80));
            }
            //for (int i = 0; i < Cpus.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {Cpus[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {Cpus[i].Model}");
            //    Console.WriteLine($"Сокет : {Cpus[i].Socket}");
            //    Console.WriteLine($"Цена : {Cpus[i].Price}");
            //    Console.WriteLine("================================================================");
            //}



        }
    }
}
