using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using System.Text.RegularExpressions;
using Flurl.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ParserForMyApp.Parser
{
    public class BaseParser
    {
        protected string nameSelector = "h1.huge";
        protected string manufacturerSelector = "td#tdsa2943";
        protected string modelSelector = "td#tdsa2944";
        protected string hherzSelector = "td#tdsa3808";
        protected string coreSelector = "td#tdsa2557";
        protected string streamsSelector = "td#tdsa23450";
        protected string socketSelector = "td#tdsa1307";
        protected string massSelector = "td#tdsa1672";
        //protected string priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";
        protected string priceSelector = "div.price.pc-component-non-used.pc-component-inactive";
        protected string powerGpuSelector = "td#tdsa44456";
        protected string powerSelectorNull = "td#tdsa893";
        protected string techprocSelector = "td#tdsa3735";
        protected string memorySizeGpuSelector = "td#tdsa689";
        protected string memoryTypeSelectorGpu = "td#tdsa4187";
        protected string formSelector = "td#tdsa643";
        protected string modelSelectornull = "td#tdsa2944";
        protected string materialSelector = "td#tdsa2399";
        protected string formSelectorNull = "td#tdsa25875";
        protected string sertifSelector = "td#tdsa2027";
        protected string MemorySizeSelector = "td#tdsa3360";
        protected string NmodulSelector = "td#tdsa4273";
        protected string DDRSelector = "td#tdsa2510";
        protected string IntegratedGraphicsCpuSelector = "td#tdsa5486";  //CPU
        protected string memoryTypeCpuSelector = "td#tdsa642";
        protected string maxMemoryTypeCpuSelector = "td#tdsa3427";
        protected string maxMemorySizeCpuSelector = "td#tdsa894";
        protected string criticalTempCpuSelector = "td#tdsa1755";
        protected string verDisplayPortGpuSelector = "td#tdsa38306";    //GPU
        protected string maxScreenResolutionGpuSelector = "td#tdsa691";
        protected string verHdmiGpuSelector = "td#tdsa38307";
        protected string herzMemoryGpuSelector = "td#tdsa4189";
        protected string chipsetMotherSelector = "td#tdsa3362";     //Motherboard
        protected string memoryTypeMotherSelector = "td#tdsa642";
        protected string memorySlotsMotherSelector = "td#tdsa146190";
        protected string maxMemoryHerzMotherSelector = "td#tdsa3427";
        protected string numM2MotherSelector = "td#tdsa6331";
        protected string maxMemorySizeMotherSelector = "td#tdsa894";
        protected string MemoryHerzRamSelector = "td#tdsa1475";         //RAM
        protected string MemorySizeSsdSelector = "td#tdsa3978";         //SSD
        protected string ssdInterfaceSelector = "td#tdsa4770";
        protected string formatSsdSelector = "td#tdsa3997";
        protected string controllerSsdSelector = "td#tdsa906";
        protected string chipTypeSsdSelector = "td#tdsa3527";
        protected string ssdResourceSelector = "td#tdsa6075";
        protected string ssdReadingSpeedSelector = "td#tdsa1396";
        protected string ssdRecordingSpeedSelector = "td#tdsa1395";
        protected string hddFormatSelector = "td#tdsa3997";                //HDD
        protected string hddMemorySizeSelector = "td#tdsa3978";
        protected string hddSpindleSpeedSelector = "td#tdsa655";
        protected string hddInterfaceSelector = "td#tdsa4771";
        protected string interfaceBandwithHddSelector = "td#tdsa917";
        protected string herzPsuSelector = "td#tdsa594";            //PSU
        protected string lenghtCablePsuSelector = "td#tdsa1578";
        protected string powerPsuSelector = "td#tdsa2123";
        protected string connectorMotherPsuSelector = "td#tdsa3162";
        protected string connectorGpuPsuSelector = "td#tdsa3387";
        protected string sizePsuSelector = "td#tdsa1539";
        protected string typeCaseSelector = "td#tdsa2510";      //Case
        protected string psuFormatCaseSelector = "td#tdsa699";
        protected string maxPsuLengthSelector = "td#tdsa7500";
        protected string usbConnectorsCaseSelector = "td#tdsa7854";
        protected string panelConnectorCaseSelector = "td#tdsa7856";
        protected string panelButtonCaseSelector = "td#tdsa706";
        protected string internalBays25CaseSelector = "td#tdsa2955";
        protected string internalBays35CaseSelector = "td#tdsa967";
        protected string maxCoolerHeightCaseSelector = "td#tdsa3508";
        protected string maxGpuLenghtCaseSelector = "td#tdsa3601";
        protected string sizeCaseSelector = "td#tdsa1539";

        readonly IConfiguration config = Configuration.Default.WithDefaultLoader();
        protected IDocument GetPage(string url)
        {
            var document = BrowsingContext.New(config).OpenAsync(url).Result;
            if (document.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Bad document status: {document.StatusCode}");
            return document;
        }
        protected List<string> GetListRef()
        {
            Console.WriteLine("Вставьте ссылку на каталог");
            var adress = Console.ReadLine();
            using var document = GetPage(adress);
            var urlSelector = "a.t";
            var cells = document.QuerySelectorAll(urlSelector).OfType<IHtmlAnchorElement>();
            var listRef = cells.Select(m => m.Href).ToList();
            return listRef;
        }
        protected async Task<string> ParseImage(IDocument doc, string dir)
        {
            string imgurl = default;
            string imgUrl2 = default;

            try { imgurl = doc.GetElementById("goods_photo").GetAttribute("href").ToString(); }
            catch (Exception ex) { imgurl = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
            try { imgUrl2 = imgurl.Substring(0, imgurl.IndexOf("?")); }
            catch (Exception ex) { imgUrl2 = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }

            string format = Regex.Replace(imgUrl2, @"\D+.+?(?=\.)", "");
            var url = imgurl ?? imgUrl2;
            Guid guid = Guid.NewGuid();
            string nameImg = $"{guid}" + $"{format}";
            await url.DownloadFileAsync(dir, nameImg);
            return nameImg;
        }

    }
}
