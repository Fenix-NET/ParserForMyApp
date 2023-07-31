using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ParserForMyApp.Models;

namespace ParserForMyApp
{
    public class ClassParsGPU : BaseParseClass
    {

        public void StartParseGPU(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга GPU");

            foreach (string link in listref)
            {
                GPU _gpu = new();
                using var doc = GetPage(link);

                _gpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";

                _gpu.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                try
                {
                    _gpu.Power = ushort.Parse(Regex.Replace(doc.QuerySelector(powerSelector).TextContent, @"\D+", ""));
                }
                catch
                {
                    try { _gpu.Power = ushort.Parse(Regex.Replace(doc.QuerySelector(powerSelectorNull).TextContent, @"\D+", "")); }
                    catch { _gpu.Power = 0; }
                }
                _gpu.Techproc = doc.QuerySelector(techprocSelector)?.TextContent ?? "n/a";

                _gpu.Memory = doc.QuerySelector(memorySelector)?.TextContent ?? "n/a";

                _gpu.MemoryType = doc.QuerySelector(memoryTypeSelector)?.FirstChild?.TextContent ?? "n/a";

                _gpu.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _gpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { _gpu.Price = 0; }

                Console.WriteLine(_gpu.Manufacturer);
                Console.WriteLine(_gpu.Model);
                Console.WriteLine(_gpu.Power);
                Console.WriteLine(_gpu.Techproc);
                Console.WriteLine(_gpu.Memory);
                Console.WriteLine(_gpu.MemoryType);
                Console.WriteLine(_gpu.Mass);
                Console.WriteLine(_gpu.Price);
                Console.WriteLine(new string('.', 80));

                _context.GPUs.Add(_gpu);

            }
            _context.SaveChanges();
            Console.WriteLine("Конец работы");
            //foreach (GPUparse gpu in _gpus)
            //{
            //    Console.WriteLine(gpu.Manufacturer);
            //    Console.WriteLine(gpu.Model);
            //    Console.WriteLine(gpu.Power);
            //    Console.WriteLine(gpu.Techproc);
            //    Console.WriteLine(gpu.Memory);
            //    Console.WriteLine(gpu.Price);
            //    Console.WriteLine(new string('.', 80));

        }
    }
}






