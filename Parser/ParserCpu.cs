using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;
using ParserForMyApp.Data;

namespace ParserForMyApp.Parser
{
    public class ParserCpu : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {
            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга CPU");
            string dir = "C:\\My Project\\PCBuilder\\Images\\CPU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Cpu _cpu = new();
                using var doc = GetPage(link);

                _cpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _cpu.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                _cpu.Hherz = doc.QuerySelector(hherzSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _cpu.Core = int.Parse(doc.QuerySelector(coreSelector)?.FirstChild.TextContent); }
                catch { _cpu.Core = null; }

                try { _cpu.Streams = int.Parse(doc.QuerySelector(streamsSelector)?.FirstChild.TextContent); }
                catch { _cpu.Streams = null; }

                _cpu.Socket = doc.QuerySelector(socketSelector).FirstChild?.TextContent ?? "n/a";
                
                try { _cpu.MemoryType = Regex.Match(doc.QuerySelector(memoryTypeCpuSelector)?.TextContent, @"(DDR.)?").Value; }
                catch { _cpu.MemoryType = "n/a"; }

                _cpu.CriticalTemp = doc.QuerySelector(criticalTempCpuSelector)?.TextContent ?? "n/a";
                _cpu.Mass = doc.QuerySelector(massSelector).FirstChild?.TextContent ?? "n/a";
                _cpu.IntegratedGraphics = doc.QuerySelector(IntegratedGraphicsCpuSelector)?.TextContent ?? "n/a";
                
                try
                {
                    _cpu.MaxMemorySize = int.Parse(Regex.Replace(doc.QuerySelector(maxMemorySizeCpuSelector)?.TextContent, @"\D+", ""));
                }
                catch (Exception)
                {
                    _cpu.MaxMemorySize = null;
                }
                
                _cpu.MaxMemoryType = doc.QuerySelector(maxMemoryTypeCpuSelector)?.TextContent ?? "n/a";
                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _cpu.Name = Regex.Replace(Name, @"^\s+", "");
                _cpu.ImageName = await ParseImage(doc, dir);

                try { _cpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                Console.WriteLine(_cpu.Name);
                Console.WriteLine(_cpu.Manufacturer);
                Console.WriteLine(_cpu.Model);
                Console.WriteLine(_cpu.Hherz);
                Console.WriteLine(_cpu.Core);
                Console.WriteLine(_cpu.Streams);
                Console.WriteLine(_cpu.Socket);
                Console.WriteLine(_cpu.IntegratedGraphics);
                Console.WriteLine(_cpu.MemoryType);
                Console.WriteLine(_cpu.MaxMemorySize);
                Console.WriteLine(_cpu.MaxMemoryType);
                Console.WriteLine(_cpu.CriticalTemp);
                Console.WriteLine(_cpu.Mass);
                Console.WriteLine(_cpu.Price);
                Console.WriteLine(_cpu.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Cpu.Add(_cpu);

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
