// See https://aka.ms/new-console-template for more information
using HtmlParserTest;

Console.WriteLine("Hello, World!");
var parse = new HtmlParse();
await parse.AngleSharpParse(DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(30).ToShortDateString(), "7616 ", "2021");
