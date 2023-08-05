// See https://aka.ms/new-console-template for more information
using System;
using ParserForMyApp;
using ParserForMyApp.Data;

Console.WriteLine("Старт программы");
//ImageGpuParse imagGpu = new();
using ParserContext parserContext = new ParserContext();
//await imagGpu.StartParsImage(parserContext);

//ImagesCpuParse imgCpu = new();
////using ParserContext parserContext = new ParserContext();
//await imgCpu.StartParsImage(parserContext);

ImageMotherParse imgMother = new();
await imgMother.StartParsImage(parserContext);

ImagePsuParse imgPsu = new();
await imgPsu.StartParsImage(parserContext);

ImageRamParse imgRam = new();
await imgRam.StartParsImage(parserContext);

ImageCaseParse imgCase = new();
await imgCase.StartParsImage(parserContext);
//Console.WriteLine(new string('.', 80));
//TestCpuParse testCpuParse = new TestCpuParse();
//using ParserContext parserContext = new ParserContext();
//testCpuParse.StartParsCpu(parserContext);
Console.WriteLine("Конец");

////https://tula.nix.ru/price.html?section=video_cards_all#c_id=101&fn=101&g_id=524&page=1&sort=%2Bp965%2B214%2B215&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера видеокарт");
//ClassParsGpu classParsGpu = new();
//using ParserContext parserContext = new ParserContext();
//await classParsGpu.StartParseGpu(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=7&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера процессоров");
//ClassParsCpu classParsCpu = new();
//await classParsCpu.StartParsCpu(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=motherboards_all#c_id=102&fn=102&g_id=3&page=1&sort=%2Bp79%2B1011%2B1008%2B127%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Материнских плат");
//ClassParseMother classParseMother = new();
//await classParseMother.StartParsMother(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=power_supplies_all#c_id=772&fn=772&g_id=631&page=1&sort=%2Bp6920%2B127%2B998%2B2289&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера Блоков питания");
//ClassParsPsu classParsPsu = new();
//await classParsPsu.StartParsePsu(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=memory_modules_all#c_id=182&fn=182&g_id=1140&page=1&sort=%2Bp327%2B1965&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера оперативной памяти");
//ClassParsRam classParsRam = new();
//await classParsRam.StartParseRam(parserContext);
//Console.WriteLine(new string('.', 80));

////https://tula.nix.ru/price.html?section=cases_all#c_id=166&fn=166&g_id=162&page=1&sort=%2Bp1764%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2
//Console.WriteLine("Запуск парсера корпусов");
//ClassParsCase classParsCase = new();
//await classParsCase.StartParsCase(parserContext);
//Console.WriteLine(new string('.', 80));

Console.ReadLine();
