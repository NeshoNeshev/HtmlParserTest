using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace HtmlParserTest
{
    public  class HtmlParse
    {
        public  async Task AngleSharpParse(string start, string end, string caseNumber, string year)
        {
            List<string> cases = new List<string>();

            string url = "https://srs.justice.bg/bg/12684?from={0}&to={1}&casenumber={2}&caseyear={3}";
            var sdasdasds = String.Format(url, start.Remove(start.Length -2), end.Remove(start.Length - 2), caseNumber, year);
            string html = "";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(sdasdasds).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        html = content.ReadAsStringAsync().Result;
                    }
                }
            }
            using var context = BrowsingContext.New(Configuration.Default);
            using var doc = await context.OpenAsync(req => req.Content(html));
            var els = doc.QuerySelectorAll("td");
            if (els.Length > 0)
            {
                foreach (var e in els)
                {
                    cases.Add(e.Text());
                    Console.WriteLine(e.Text());
                }
               var adas = new Case();
                adas.NumberOfCase = cases[2];
                adas.Type = cases[1];
                adas.Judge = cases[5];
                adas.Date = DateTime.Parse(cases[7]);
            }
            else
            {
                Console.WriteLine("0");
            }
            Console.WriteLine("");
        }
    }
}
