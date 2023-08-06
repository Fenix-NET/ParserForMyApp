using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;
using ParserForMyApp.Data;

namespace ParserForMyApp.Parser
{
    public class ParserCase : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {
            Console.WriteLine("Подготовка парсера");

            List<string> listref = GetListRef(); ;

            Console.WriteLine("Начало парсинга Корпусов");


            foreach (string link in listref)
            {
                Case _case = new();
                using var doc = GetPage(link);

                _case.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _case.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Form = doc.QuerySelector(formSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                _case.Materials = doc.QuerySelector(materialSelector)?.FirstChild?.TextContent ?? "n/a";

                // string price = Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "");
                try { _case.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _case.Price = 0; }

                _case.Name = doc.QuerySelector(nameSelector)?.TextContent ?? "n/a";

                _case.ImageName = doc.QuerySelector()

                Console.WriteLine(_case.Name);
                Console.WriteLine(_case.Manufacturer);
                Console.WriteLine(_case.Model);
                Console.WriteLine(_case.Form);
                Console.WriteLine(_case.Mass);
                Console.WriteLine(_case.Materials);
                Console.WriteLine(_case.Price);
                Console.WriteLine(_case.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Case.Add(_case);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (Caseparse casee in _cases)
            //{
            //    Console.WriteLine(casee.Manufacturer);
            //    Console.WriteLine(casee.Model);
            //    Console.WriteLine(casee.Form);
            //    Console.WriteLine(casee.Price);
            //    Console.WriteLine(new string('.', 80));
            //}


        }


    }
}
