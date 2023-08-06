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

            foreach (string link in listref)
            {
                Hdd _hdd = new();
                using var doc = GetPage(link);

                _hdd.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _hdd.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _hdd.MemorySize = doc.QuerySelector(hddMemorySizeSelector)?.FirstChild?.TextContent ?? "n/a";

                _hdd.SpindleSpeed = doc.QuerySelector(hddSpindleSpeedSelector)?.FirstChild?.TextContent ?? "n/a";

                _hdd.Format = doc.QuerySelector(hddFormatSelector).RemoveChild(doc.QuerySelector("a")).TextContent ?? "n/a";

                _hdd.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _hdd.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _hdd.Price = 0; }

                _hdd.Name = doc.QuerySelector(nameSelector)?.TextContent ?? "n/a";

                _hdd.ImageName = doc.QuerySelector()


                Console.WriteLine(_hdd.Name);
                Console.WriteLine(_hdd.Manufacturer);
                Console.WriteLine(_hdd.Model);
                Console.WriteLine(_hdd.MemorySize);
                Console.WriteLine(_hdd.SpindleSpeed);
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
