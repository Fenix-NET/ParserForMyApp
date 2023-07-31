using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ParserForMyApp
{
    public class BaseParseClass
    {
        protected string manufacturerSelector = "td#tdsa2943";
        protected string modelSelector = "td#tdsa2944";
        protected string hherzSelector = "td#tdsa3808";
        protected string coreSelector = "td#tdsa2557";
        protected string streamsSelector = "td#tdsa23450";
        protected string socketSelector = "td#tdsa1307";
        protected string massSelector = "td#tdsa1672";
        protected string priceSelector = "a.add_to_cart.btn.btn-t-0.btn-c-6.CanBeSold.pc-component";
        protected string powerSelector = "td#tdsa44456";
        protected string powerSelectorNull = "td#tdsa893";
        protected string techprocSelector = "td#tdsa3735";
        protected string memorySelector = "td#tdsa689";
        protected string memoryTypeSelector = "td#tdsa4187";   
        protected string formSelector = "td#tdsa2510";
        protected string modelSelectornull = "td#tdsa2944";
        protected string materialSelector = "td#tdsa2399";
        protected string formSelectorNull = "td#tdsa25875";
        protected string sertifSelector = "td#tdsa2027";
        protected string MemorySelector = "td#tdsa3360";
        protected string NmodulSelector = "td#tdsa4273";
        protected string DDRSelector = "td#tdsa2510";

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


    }
}
