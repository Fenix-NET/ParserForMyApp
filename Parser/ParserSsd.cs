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

            foreach (string link in listref)
            {
                Ssd _ssd = new();
                using var doc = GetPage(link);

                _ssd.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _ssd.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _ssd.MemorySize = doc.QuerySelector(DDRSelector)?.FirstChild?.TextContent ?? "n/a";

                _ssd.SsdInterface = doc.QuerySelector(ssdInterfaceSelector)?.TextContent ?? "n/a";

                _ssd.ReadingSpeed = doc.QuerySelector(ssdReadingSpeedSelector)?.TextContent ?? "n/a";

                _ssd.RecordingSpeed = doc.QuerySelector(ssdRecordingSpeedSelector)?.TextContent ?? "n/a";

                _ssd.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _ssd.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _ssd.Price = 0; }

                _ssd.Name = Regex.Replace(doc.QuerySelector(nameSelector)?.FirstChild?.TextContent, @"^\W+", "");

                //_ssd.ImageName = doc.QuerySelector()


                Console.WriteLine(_ssd.Name);
                Console.WriteLine(_ssd.Manufacturer);
                Console.WriteLine(_ssd.Model);
                Console.WriteLine(_ssd.MemorySize);
                Console.WriteLine(_ssd.SsdInterface);
                Console.WriteLine(_ssd.ReadingSpeed);
                Console.WriteLine(_ssd.RecordingSpeed);
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
