using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;
using ParserForMyApp.Data;

namespace ParserForMyApp.Parser
{
    public class ParserRam : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга RAM");
            string dir = "C:\\My Project\\PCBuilder\\Images\\RAM";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Ram _ram = new();
                using var doc = GetPage(link);

                _ram.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _ram.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                try {_ram.MemoryType = Regex.Match(doc.QuerySelector(DDRSelector)?.FirstChild?.TextContent, @"(DDR.)").Value; }
                catch { _ram.MemoryType = "n/a"; }

                try { _ram.MemorySize = int.Parse(Regex.Replace(doc.QuerySelector(MemorySizeSelector).FirstChild.TextContent, @"\D+", "")); }
                catch (Exception ex) { _ram.MemorySize = null; }

                try { _ram.Nmodule = byte.Parse(doc.QuerySelector(NmodulSelector)?.FirstChild.TextContent); }
                catch (Exception ex) { continue; }

                _ram.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _ram.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                try { _ram.MemoryHerz = doc.QuerySelector(MemoryHerzRamSelector).TextContent ?? "n/a";}
                catch (NullReferenceException) { continue; }
                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _ram.Name = Regex.Replace(Name, @"^\s+", "");
                _ram.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_ram.Name);
                Console.WriteLine(_ram.Manufacturer);
                Console.WriteLine(_ram.Model);
                Console.WriteLine(_ram.MemoryType);
                Console.WriteLine(_ram.MemorySize);
                Console.WriteLine(_ram.Nmodule);
                Console.WriteLine(_ram.MemoryHerz);
                Console.WriteLine(_ram.Mass);
                Console.WriteLine(_ram.Price);
                Console.WriteLine(_ram.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Ram.Add(_ram);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (RAMparse ram in _rams)
            //{
            //    Console.WriteLine(ram.Manufacturer);
            //    Console.WriteLine(ram.Model);
            //    Console.WriteLine(ram.DDR);
            //    Console.WriteLine(ram.Memory);
            //    Console.WriteLine(ram.Price);
            //    Console.WriteLine(new string('.', 80));
            //}
            //for (int i = 0; i < RAMs.Count; i++)
            //{
            //    Console.WriteLine($"Производитель : {RAMs[i].Manufacturer}");
            //    Console.WriteLine($"Модель : {RAMs[i].Model}");
            //    Console.WriteLine($"Объем памяти : {RAMs[i].Memory}");
            //    Console.WriteLine($"Тип памяти : {RAMs[i].DDR}");
            //    Console.WriteLine($"Цена : {RAMs[i].Price}");
            //    Console.WriteLine("================================================================");
            //}

        }



    }
}
