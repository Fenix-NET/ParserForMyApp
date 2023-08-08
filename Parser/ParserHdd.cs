using ParserForMyApp.Data;
using ParserForMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserForMyApp.Parser
{
    public class ParserHdd : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга HDD");
            string dir = "C:\\My Project\\PCBuilder\\Images\\HDD";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Hdd _hdd = new();
                using var doc = GetPage(link);

                _hdd.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _hdd.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                string mem = doc.QuerySelector(hddMemorySizeSelector)?.FirstChild?.TextContent ?? "n/a";
                _hdd.MemorySize = mem.Trim();
                if (_hdd.MemorySize == "n/a")
                    continue;
                
                _hdd.SpindleSpeed = (doc.QuerySelector(hddSpindleSpeedSelector)?.FirstChild?.TextContent)?.Trim() ?? "n/a";

                try { _hdd.HddInterface = (Regex.Replace(doc.QuerySelector(hddInterfaceSelector).TextContent, @"(интерфейсный кабель для HDD/SSD)", "")).Trim();}
                catch { continue; }
                
                _hdd.InterfaceBandwidth = (doc.QuerySelector(interfaceBandwithHddSelector)?.TextContent)?.Trim() ?? "n/a";
                if(_hdd.InterfaceBandwidth == "n/a")
                { continue; }
                
                try { _hdd.Format = Regex.Replace(doc.QuerySelector(hddFormatSelector).TextContent, @"(внешние боксы для HDD/SSD)", "");}
                catch { continue; }
                
                _hdd.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _hdd.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _hdd.Name = Regex.Replace(Name, @"^\s+", "");
                _hdd.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_hdd.Name);
                Console.WriteLine(_hdd.Manufacturer);
                Console.WriteLine(_hdd.Model);
                Console.WriteLine(_hdd.MemorySize);
                Console.WriteLine(_hdd.SpindleSpeed);
                Console.WriteLine(_hdd.HddInterface);
                Console.WriteLine(_hdd.InterfaceBandwidth);
                Console.WriteLine(_hdd.Format);
                Console.WriteLine(_hdd.Mass);
                Console.WriteLine(_hdd.Price);
                Console.WriteLine(_hdd.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Hdd.Add(_hdd);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");

        }


    }
}
