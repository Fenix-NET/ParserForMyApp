using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ParserForMyApp.Data;
using ParserForMyApp.Models;

namespace ParserForMyApp.Parser
{
    public class ParserPsu : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга PSU");
            string dir = "C:\\My Project\\PCBuilder\\Images\\PSU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Psu _psu = new();
                using var doc = GetPage(link);

                _psu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _psu.Model = doc.QuerySelector(modelSelector)?.FirstChild.TextContent ?? "n/a";
                _psu.Herz = doc.QuerySelector(herzPsuSelector)?.TextContent ?? "n/a";
                _psu.LenghtCable = doc.QuerySelector(lenghtCablePsuSelector)?.TextContent ?? "n/a";

                try { _psu.Power = int.Parse(Regex.Replace(doc.QuerySelector(powerPsuSelector).TextContent, @"\D+", "")); }
                catch (Exception ex) { _psu.Power = null; }

                try { _psu.Sertificate = Regex.Replace(doc.QuerySelector(sertifSelector).TextContent, @"^.+?(?=80)", ""); }  //@"\W+\D+", ""
                catch (Exception ex) { _psu.Sertificate = "n/a"; }

                try { _psu.ConnectorMotherboard = Regex.Replace(doc.QuerySelector(connectorMotherPsuSelector)?.TextContent, @"(удлинители питания мат\.платы)", "");}
                catch { _psu.ConnectorMotherboard = "n/a"; }

                _psu.ConnectorGpu = doc.QuerySelector(connectorGpuPsuSelector)?.TextContent ?? "n/a";
                _psu.Size = doc.QuerySelector(sizePsuSelector)?.TextContent ?? "n/a";
                _psu.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _psu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _psu.Name = Regex.Replace(Name, @"^\s+", "");
                _psu.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_psu.Name);
                Console.WriteLine(_psu.Manufacturer);
                Console.WriteLine(_psu.Model);
                Console.WriteLine(_psu.Herz);
                Console.WriteLine(_psu.LenghtCable);
                Console.WriteLine(_psu.Power);
                Console.WriteLine(_psu.Sertificate);
                Console.WriteLine(_psu.ConnectorMotherboard);
                Console.WriteLine(_psu.ConnectorGpu);
                Console.WriteLine(_psu.Size);
                Console.WriteLine(_psu.Mass);
                Console.WriteLine(_psu.Price);
                Console.WriteLine(_psu.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Psu.Add(_psu);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (PSUParse psu in _psus)
            //{
            //    Console.WriteLine(psu.Manufacturer);
            //    Console.WriteLine(psu.Model);
            //    Console.WriteLine(psu.Power);
            //    Console.WriteLine(psu.Price);
            //    Console.WriteLine(new string('.', 80));

        }


    }
}
