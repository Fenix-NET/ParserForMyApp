// See https://aka.ms/new-console-template for more information
using System;
using ParserForMyApp.Data;
using ParserForMyApp.Parser;

Console.WriteLine("Старт программы");
//IParser imgGpu = new ImageGpuParser();
using ParserContext parserContext = new ParserContext();
//await imgGpu.StartParse(parserContext);

//IParser imgCpu = new ImageCpuParser();
////using ParserContext parserContext = new ParserContext();
//await imgCpu.StartParse(parserContext);

IParser imgMother = new ImageMotherParser();
await imgMother.StartParse(parserContext);

IParser imgPsu = new ImagePsuParser();
await imgPsu.StartParse(parserContext);

IParser imgRam = new ImageRamParser();
await imgRam.StartParse(parserContext);

IParser imgCase = new ImageCaseParser();
await imgCase.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));
//TestCpuParse testCpuParse = new TestCpuParse();
//using ParserContext parserContext = new ParserContext();
//testCpuParse.StartParse(parserContext);
Console.WriteLine("Конец");

////https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=524&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера видеокарт");
//IParser parsGpu = new ParserGpu();
//using ParserContext parserContext = new ParserContext();
//await parsGpu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=7&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера процессоров");
//IParser parsCpu = new ParserCpu();
//await parsCpu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=3&page=1&sort=%2Bp79%2B1011%2B1008%2B127%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Материнских плат");
//IParser classParseMother = new ParserMother();
//await parseMother.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=power_supplies_all#c_id=772&fn=772&g_id=631&page=1&sort=%2Bp6920%2B127%2B998%2B2289&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Блоков питания");
//IParser parsPsu = new ParserPsu();
//await parsPsu.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=memory_modules_all#c_id=182&fn=182&g_id=1140&page=1&sort=%2Bp327%2B1965&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера оперативной памяти");
//IParser parsRam = new ParserRam();
//await parsRam.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=cases_all#c_id=166&fn=166&g_id=162&page=1&sort=%2Bp1764%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера корпусов");
//IParser parsCase = new ParserCase();
//await parsCase.StartParse(parserContext);
//Console.WriteLine(new string('.', 80));

Console.ReadLine();
