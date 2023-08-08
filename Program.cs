// See https://aka.ms/new-console-template for more information
using System;
using ParserForMyApp.Data;
using ParserForMyApp.Parser;

Console.WriteLine("Старт программы");
//IParser imgGpu = new ImageGpuParser();
//using ParserContext parserContext = new ParserContext();
//await imgGpu.StartParse(parserContext);

//IParser imgCpu = new ImageCpuParser();
////using ParserContext parserContext = new ParserContext();
//await imgCpu.StartParse(parserContext);

//IParser imgMother = new ImageMotherParser();
//await imgMother.StartParse(parserContext);

//IParser imgPsu = new ImagePsuParser();
//await imgPsu.StartParse(parserContext);

//IParser imgRam = new ImageRamParser();
//await imgRam.StartParse(parserContext);

//IParser imgCase = new ImageCaseParser();
//await imgCase.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));
//TestCpuParse testCpuParse = new TestCpuParse();
//using ParserContext parserContext = new ParserContext();
//testCpuParse.StartParse(parserContext);


////https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=2568&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера видеокарт");
//IParser parsGpu = new ParserGpu();
using ParserContext parserContext = new ParserContext();
//await parsGpu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://www.nix.ru/price/price_list.html?section=cpu_intel#c_id=161&fn=159&g_id=127&page=1&sort=r&spoiler=&store=msk-0_1721_1&thumbnail_view=2
//https://www.nix.ru/price/price_list.html?section=cpu_amd#c_id=161&fn=7&g_id=7&page=all&sort=%2Bp8175%2B7287%2B766%2B2326&spoiler=&store=msk-0_1721_1&thumbnail_view=2
//Console.WriteLine("Запуск парсера процессоров");
//IParser parsCpu = new ParserCpu();
//await parsCpu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=281&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Материнских плат");
//IParser parseMother = new ParserMother();
//await parseMother.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=power_supplies_all#c_id=772&fn=772&g_id=649&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Блоков питания");
//IParser parsPsu = new ParserPsu();
//await parsPsu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=memory_modules_all#c_id=182&fn=182&g_id=2332&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера оперативной памяти");
//IParser parsRam = new ParserRam();
//await parsRam.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=ssd_all#c_id=900&fn=900&g_id=998&page=all&sort=r&spoiler=1&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера SSD");
//IParser parsSsd = new ParserSsd();
//await parsSsd.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=hdd_all#c_id=103&fn=103&g_id=12&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Hdd");
//IParser parsHdd = new ParserHdd();
//await parsHdd.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=cases_all#c_id=166&fn=166&g_id=641&page=1&sort=r&spoiler=&store=best_seller_region-1483_0&thumbnail_view=2
Console.WriteLine("Запуск парсера корпусов");
IParser parsCase = new ParserCase();
await parsCase.StartParse(parserContext);
Console.WriteLine(new string('.', 80));
Console.WriteLine("Конец");
Console.ReadLine();
