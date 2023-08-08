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
    public class ParserSsd : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга SSD");
            string dir = "C:\\My Project\\PCBuilder\\Images\\SSD";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Ssd _ssd = new();
                using var doc = GetPage(link);

                _ssd.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _ssd.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _ssd.MemorySize = Regex.Replace(doc.QuerySelector(MemorySizeSsdSelector)?.FirstChild.TextContent, @"популярный SSD такого объема", "");}
                catch(ArgumentNullException) { continue; }

                try { _ssd.SsdInterface = Regex.Replace(doc.QuerySelector(ssdInterfaceSelector)?.TextContent, @"(интерфейсный кабель для HDD/SSD)", "");}
                catch(ArgumentNullException) { continue; }    
                _ssd.SsdResource = doc.QuerySelector(ssdResourceSelector)?.TextContent ?? "n/a";
                _ssd.ReadingSpeed = doc.QuerySelector(ssdReadingSpeedSelector)?.TextContent ?? "n/a";
                _ssd.RecordingSpeed = doc.QuerySelector(ssdRecordingSpeedSelector)?.TextContent ?? "n/a";
                if(_ssd.ReadingSpeed == "n/a" && _ssd.RecordingSpeed == "n/a")
                    { continue; }
                _ssd.Controller = doc.QuerySelector(controllerSsdSelector)?.TextContent ?? "n/a";
                _ssd.ChipType = doc.QuerySelector(chipTypeSsdSelector)?.TextContent ?? "n/a";
                if(_ssd.Controller == "n/a" && _ssd.ChipType == "n/a")
                {
                    continue;
                }
                
                try { _ssd.Format = Regex.Replace(doc.QuerySelector(formatSsdSelector).TextContent, @"(внешние боксы для HDD/SSD)", "");}
                catch(NullReferenceException) { continue; }
                _ssd.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _ssd.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _ssd.Name = Regex.Replace(Name, @"^\s+", "");
                _ssd.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_ssd.Name);
                Console.WriteLine(_ssd.Manufacturer);
                Console.WriteLine(_ssd.Model);
                Console.WriteLine(_ssd.MemorySize);
                Console.WriteLine(_ssd.SsdInterface);
                Console.WriteLine(_ssd.SsdResource);
                Console.WriteLine(_ssd.ReadingSpeed);
                Console.WriteLine(_ssd.RecordingSpeed);
                Console.WriteLine(_ssd.Controller);
                Console.WriteLine(_ssd.ChipType);
                Console.WriteLine(_ssd.Format);
                Console.WriteLine(_ssd.Mass);
                Console.WriteLine(_ssd.Price);
                Console.WriteLine(_ssd.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Ssd.Add(_ssd);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");

        }
    }
}    
