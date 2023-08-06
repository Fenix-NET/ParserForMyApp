﻿using Flurl.Http;
using ParserForMyApp.Data;
using ParserForMyApp.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserForMyApp.Parser.ImageParser
{
    public class ImagePsuParser : BaseParser, IParser
    {

        public async Task StartParse(ParserContext context)
        {
            Console.WriteLine("Парсинг PSU");
            var listref = GetListRef();
            var modelSelector = "td#tdsa2944";

            var dir = "C:\\My Project\\PCBuilder\\Images\\PSU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                ImagePsu Img = new();
                using var doc = GetPage(link);
                string imgurl = default;
                string imgUrl2 = default;
                string editor = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                Img.PsuModel = editor.Replace('/', '-') ?? "n/a";
                //var imgUrl = doc.GetElementById("goods_photo").GetAttribute("href").ToString();
                try { imgurl = doc.GetElementById("goods_photo").GetAttribute("href").ToString(); }
                catch (Exception ex) { imgurl = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                try { imgUrl2 = imgurl.Substring(0, imgurl.IndexOf("?")); }
                catch (Exception ex) { imgUrl2 = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                //string formatimg = imgUrl2.Substring(2, imgUrl.IndexOf("."));
                string format = Regex.Replace(imgUrl2, @"\D+.+?(?=\.)", "");       // Это ОНО!

                string localFilename = $"{dir}" + "\\" + $"{Img.PsuModel}" + $"{format}";

                var url = imgurl ?? imgUrl2;
                Random random = new Random();
                int indx = random.Next(100, 9999);
                await url.DownloadFileAsync(dir, localFilename = $"{Img.PsuModel}" + "-" + $"{indx}" + $"{format}");

                Img.ImageDir = localFilename;
                context.ImagePsus.Add(Img);
                Console.WriteLine(Img.PsuModel);
            }
            context.SaveChanges();
            Console.WriteLine("DB Finally!");
        }
    }
}