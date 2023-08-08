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
            string dir = "C:\\My Project\\PCBuilder\\Images\\Motherboard";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Motherboard _mother = new();
                using var doc = GetPage(link);

                _mother.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _mother.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                _mother.Socket = doc.QuerySelector(socketSelector)?.FirstChild?.TextContent ?? "n/a";

                //try { _mother.Form = Regex.Replace(doc.QuerySelector(formSelector).FirstChild.Text(), @"\W+\d+\D+\d+\D+", ""); }
                //catch (Exception ex) { _mother.Form = doc.QuerySelector(formSelectorNull)?.FirstChild?.TextContent ?? "n/a"; };
                _mother.Form = doc.QuerySelector(formSelector)?.TextContent ?? "n/a";
                _mother.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _mother.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                try { _mother.Chipset = Regex.Replace(doc.QuerySelector(chipsetMotherSelector)?.TextContent, @"(характеристики чипсета)", "");}
                catch (ArgumentNullException) { continue; }

                try { _mother.MemoryType = Regex.Match(doc.QuerySelector(memoryTypeMotherSelector)?.TextContent, @"(DDR.)").Value;}
                catch (ArgumentNullException) { _mother.MemoryType = null; }
                

                try { _mother.MemorySlots = int.Parse(doc.QuerySelector(memorySlotsMotherSelector).TextContent);}
                catch (NullReferenceException) { _mother.MemorySlots = null; }
                
                try {_mother.MaxMemoryHerz = Regex.Replace(doc.QuerySelector(maxMemoryHerzMotherSelector).TextContent, @"(совместимая память)", ""); }
                catch (NullReferenceException) { _mother.MaxMemoryHerz = "n/a"; }
                
                try { _mother.NumM2 = byte.Parse(Regex.Replace(doc.QuerySelector(numM2MotherSelector).FirstChild?.TextContent, @"\s\S+", "")); }
                catch { _mother.NumM2 = 0; }
                
                try { _mother.MaxMemorySize = int.Parse(Regex.Replace(doc.QuerySelector(maxMemorySizeMotherSelector)?.TextContent, @"\s\S+", "")); }
                catch { _mother.MaxMemorySize = null; }

                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _mother.Name = Regex.Replace(Name, @"^\s+", "");
                _mother.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_mother.Name);
                Console.WriteLine(_mother.Manufacturer);
                Console.WriteLine(_mother.Model);
                Console.WriteLine(_mother.Socket);
                Console.WriteLine(_mother.Form);
                Console.WriteLine(_mother.Chipset);
                Console.WriteLine(_mother.MaxMemorySize);
                Console.WriteLine("Тип памяти: " + _mother.MemoryType);
                Console.WriteLine("Слотов RAM: " + _mother.MemorySlots);
                Console.WriteLine(_mother.MaxMemoryHerz);
                Console.WriteLine("Слотов М2: " + _mother.NumM2);
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
