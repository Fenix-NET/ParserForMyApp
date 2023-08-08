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
            string dir = "C:\\My Project\\PCBuilder\\Images\\Case";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                Case _case = new();
                using var doc = GetPage(link);

                _case.Manufacturer = (doc.QuerySelector(manufacturerSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.Model = (doc.QuerySelector(modelSelector)?.FirstChild?.TextContent)?.Trim() ?? "n/a";

                try {  _case.Type = Regex.Replace(doc.QuerySelector(typeCaseSelector)?.TextContent, @"(Корпус )", "");}
                catch { continue; }
                
                _case.Form = (doc.QuerySelector(formSelector)?.FirstChild?.TextContent)?.Trim() ?? "n/a";
                _case.PsuFormat = (doc.QuerySelector(psuFormatCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.MaxPsuLength = (doc.QuerySelector(maxPsuLengthSelector)?.TextContent)?.Trim() ?? "n/a";
                if (_case.Form == "n/a" || _case.PsuFormat == "n/a" || _case.MaxPsuLength == "n/a")
                    continue;
                _case.UsbConnectors = (doc.QuerySelector(usbConnectorsCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.PanelConnector = (doc.QuerySelector(panelConnectorCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.PanelButton = (doc.QuerySelector(panelButtonCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.InternalBays25 = (doc.QuerySelector(internalBays25CaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.InternalBays35 = (doc.QuerySelector(internalBays35CaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.MaxCoolerHeight = (doc.QuerySelector(maxCoolerHeightCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.MaxGpuLenght = (doc.QuerySelector(maxGpuLenghtCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                if (_case.MaxCoolerHeight == "n/a" || _case.MaxGpuLenght == "n/a")
                    continue;
                
                _case.Size = (doc.QuerySelector(sizeCaseSelector)?.TextContent)?.Trim() ?? "n/a";
                _case.Mass = doc.QuerySelector(massSelector)?.FirstChild?.TextContent ?? "n/a";
                _case.Materials = doc.QuerySelector(materialSelector)?.FirstChild?.TextContent ?? "n/a";
                // string price = Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "");
                try { _case.Price = decimal.Parse(Regex.Replace(doc.QuerySelector(priceSelector)?.TextContent, @"\D+", "")); }
                catch (Exception ex) { continue; }

                string Name = Regex.Replace(doc.QuerySelector(nameSelector)?.TextContent, @"(Выбор редакции)\s+", "");
                _case.Name = Regex.Replace(Name, @"^\s+", "");
                _case.ImageName = await ParseImage(doc, dir);

                Console.WriteLine(_case.Name);
                Console.WriteLine(_case.Manufacturer);
                Console.WriteLine(_case.Model);
                Console.WriteLine(_case.Type);
                Console.WriteLine(_case.Form);
                Console.WriteLine(_case.PsuFormat);
                Console.WriteLine(_case.MaxPsuLength);
                Console.WriteLine(_case.UsbConnectors);
                Console.WriteLine(_case.PanelConnector);
                Console.WriteLine(_case.PanelButton);
                Console.WriteLine(_case.InternalBays25);
                Console.WriteLine(_case.InternalBays35);
                Console.WriteLine(_case.MaxCoolerHeight);
                Console.WriteLine(_case.MaxGpuLenght);
                Console.WriteLine(_case.Materials);
                Console.WriteLine(_case.Size);
                Console.WriteLine(_case.Mass);
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
