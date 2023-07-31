﻿using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;

namespace ParserForMyApp
{                                                       //Выделение общей логики в отдельные сервисы
    public class ClassParseMother : BaseParseClass                   //Оптимизация работы и времени отклика.
    {

        public async Task StartParsMother(ParserContext _context)
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

                Console.WriteLine(_mother.Manufacturer);
                Console.WriteLine(_mother.Model);
                Console.WriteLine(_mother.Socket);
                Console.WriteLine(_mother.Form);
                Console.WriteLine(_mother.Mass);
                Console.WriteLine(_mother.Price);
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
