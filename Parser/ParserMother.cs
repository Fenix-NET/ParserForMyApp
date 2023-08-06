using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;
using ParserForMyApp.Data;

namespace ParserForMyApp.Parser
{                                                       //Выделение общей логики в отдельные сервисы
    public class ParserMother : BaseParser, IParser                   //Оптимизация работы и времени отклика.
    {

        public async Task StartParse(ParserContext _context)
        {
            Console.WriteLine("Подготовка парсера");

            List<string> listref = GetListRef();

            Console.WriteLine("Начало парсинга Motherboard");

            foreach (string link in listref)
            {
                Motherboard _mother = new();
                using var doc = GetPage(link);

                _mother.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _mother.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                _mother.Socket = doc.QuerySelector(socketSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _mother.Form = Regex.Replace(doc.QuerySelector(formSelector).FirstChild.Text(), @"\W+\d+\D+\d+\D+", ""); }
                catch (Exception ex) { _mother.Form = doc.QuerySelector(formSelectorNull)?.FirstChild?.TextContent ?? "n/a"; };

                _mother.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _mother.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _mother.Price = 0; }

                _mother.Chipset = doc.QuerySelector(chipsetMotherSelector)
                _mother.MemoryType = doc.QuerySelector(memoryTypeMotherSelector)
                _mother.MemorySlots = doc.QuerySelector(memorySlotsMotherSelector)
                _mother.MaxMemoryHerz = doc.QuerySelector(maxMemoryHerzMotherSelector)
                _mother.NumM2 = doc.QuerySelector(numM2MotherSelector)
                _mother.MaxMemorySize = doc.QuerySelector(maxMemorySizeMotherSelector)
                _mother.Name = doc.QuerySelector(nameSelector)
                _mother.ImageName = doc.QuerySelector()

                Console.WriteLine(_mother.Name);
                Console.WriteLine(_mother.Manufacturer);
                Console.WriteLine(_mother.Model);
                Console.WriteLine(_mother.Socket);
                Console.WriteLine(_mother.Form);
                Console.WriteLine(_mother.Chipset);
                Console.WriteLine(_mother.MemoryType);
                Console.WriteLine(_mother.MemorySlots);
                Console.WriteLine(_mother.MaxMemoryHerz);
                Console.WriteLine(_mother.NumM2);
                Console.WriteLine(_mother.MaxMemorySize);
                Console.WriteLine(_mother.Mass);
                Console.WriteLine(_mother.Price);
                Console.WriteLine(_mother.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Motherboards.Add(_mother);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (MotherParse mother in _mothers)
            //{
            //    Console.WriteLine(mother.Manufacturer);
            //    Console.WriteLine(mother.Model);
            //    Console.WriteLine(mother.Socket);
            //    Console.WriteLine(mother.Form);
            //    Console.WriteLine(mother.Price);
            //    Console.WriteLine(new string('.', 80));
            //}



        }
    }
}
