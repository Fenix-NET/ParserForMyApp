﻿using System;
using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using System.Text.RegularExpressions;
using ParserForMyApp.Models;
using ParserForMyApp.Data;

namespace ParserForMyApp.Parser
{
    public class ImageGpuParser : BaseParser, IParser //where T:class
    {
        //public string ImgUrl { get; set; }
        //public string ImgName { get; set; }
        //public string DirPath { get; set; }

        //public ImageGPUParse(string imgName, string dirpath)
        //{
        //    ImgName = imgName;
        //    DirPath = dirpath;
        //}


        //public async Task DownloadImageAsync(string directoryPath, string fileName, Uri uri)
        //{

        //    var path = Path.Combine(directoryPath, $"{fileName}{fileExtension}");
        //    Directory.CreateDirectory(directoryPath);

        //    // Download the image and write to the file
        //    var imageBytes = await httpClient.GetByteArrayAsync(uri);
        //    await File.WriteAllBytesAsync(path, imageBytes);
        //}
        public async Task StartParse(ParserContext context)
        {
            Console.WriteLine("Парсинг GPU");
            var listref = GetListRef();
            var modelSelector = "td#tdsa2944";
            var dir = "C:\\My Project\\PCBuilder\\Images\\GPU";
            Directory.CreateDirectory(dir);
            foreach (string link in listref)
            {
                ImageGpu Img = new();
                using var doc = GetPage(link);
                string imgurl = default;
                string imgUrl2 = default;
                string editor = doc.QuerySelector(modelSelector)?.FirstChild?.TextContent ?? "n/a";
                Img.GpuModel = editor.Replace('/', '-') ?? "n/a";
                //var imgUrl = doc.GetElementById("goods_photo").GetAttribute("href").ToString();
                try { imgurl = doc.GetElementById("goods_photo").GetAttribute("href").ToString(); }
                catch (Exception ex) { imgurl = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                try { imgUrl2 = imgurl.Substring(0, imgurl.IndexOf("?")); }
                catch (Exception ex) { imgUrl2 = doc.GetElementById("main_photo").GetAttribute("src").ToString(); }
                //string formatimg = imgUrl2.Substring(2, imgUrl.IndexOf("."));
                string format = Regex.Replace(imgUrl2, @"\D+.+?(?=\.)", "");       // Это ОНО!

                string localFilename = $"{dir}" + "\\" + $"{Img.GpuModel}" + $"{format}";

                var url = imgurl ?? imgUrl2;
                Random random = new Random();
                int indx = random.Next(1000, 9999);
                await url.DownloadFileAsync(dir, localFilename = $"{Img.GpuModel}" + "-" + $"{indx}" + $"{format}");

                Img.ImageDir = localFilename;
                context.ImageGpus.Add(Img);
                Console.WriteLine(Img.GpuModel);
            }
            context.SaveChanges();
            Console.WriteLine("DB Finally!");
        }

    }
}
