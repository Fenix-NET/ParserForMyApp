﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ParserForMyApp.Data;
using ParserForMyApp.Models;

namespace ParserForMyApp.Parser
{
    public class ParserGpu : BaseParser, IParser
    {

        public async Task StartParse(ParserContext _context)
        {

            List<string> listref = GetListRef();
            Console.WriteLine("Начало парсинга GPU");
            string dir = "C:\\My Project\\PCBuilder\\Images\\GPU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Gpu _gpu = new();
                using var doc = GetPage(link);

                _gpu.Manufacturer = doc.QuerySelector(manufacturerSelector)?.TextContent ?? "n/a";
                _gpu.Model = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";

                try
                {
                    _gpu.RecommendedPsuPower = int.Parse(Regex.Replace(doc.QuerySelector(powerGpuSelector).TextContent, @"\D+", ""));
                }
                catch
                {
                    _gpu.RecommendedPsuPower = null;
                }
                
                try { _gpu.Power = int.Parse(Regex.Replace(doc.QuerySelector(powerSelectorNull).TextContent, @"\D+", "")); }
                
                catch { _gpu.Power = null; }
                
                _gpu.Techproc = doc.QuerySelector(techprocSelector)?.TextContent ?? "n/a";
                
                try { _gpu.MemorySize = int.Parse(Regex.Replace(doc.QuerySelector(memorySizeGpuSelector).TextContent, @"\D+", ""));}
                catch(NullReferenceException) { continue; }
                _gpu.MemoryType = doc.QuerySelector(memoryTypeSelectorGpu)?.FirstChild?.TextContent ?? "n/a";
                _gpu.MaxScreenResolution = doc.QuerySelector(maxScreenResolutionGpuSelector)?.TextContent ?? "n/a";
                _gpu.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";

                try { _gpu.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                _gpu.VerDisplayPort = doc.QuerySelector(verDisplayPortGpuSelector)?.FirstChild?.TextContent ?? "n/a";
                _gpu.VerHdmi = doc.QuerySelector(verHdmiGpuSelector)?.FirstChild?.TextContent ?? "n/a";
                _gpu.HerzMemory = doc.QuerySelector(herzMemoryGpuSelector)?.FirstChild?.TextContent ?? "n/a";
                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _gpu.Name = Regex.Replace(Name, @"^\s+", "");
                _gpu.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_gpu.Name);
                Console.WriteLine(_gpu.Manufacturer);
                Console.WriteLine(_gpu.Model);
                Console.WriteLine(_gpu.Techproc);
                Console.WriteLine(_gpu.MemorySize);
                Console.WriteLine(_gpu.MemoryType);
                Console.WriteLine(_gpu.VerDisplayPort);
                Console.WriteLine(_gpu.VerHdmi);
                Console.WriteLine(_gpu.HerzMemory);
                Console.WriteLine(_gpu.MaxScreenResolution);
                Console.WriteLine(_gpu.RecommendedPsuPower);
                Console.WriteLine(_gpu.Power);
                Console.WriteLine(_gpu.Mass);
                Console.WriteLine(_gpu.Price);
                Console.WriteLine(_gpu.ImageName);
                Console.WriteLine(new string('.', 80));

                _context.Gpu.Add(_gpu);

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






