using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                if (args.Length == 0) throw new ArgumentException("Parametr URL nie zostal podany");

                string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
                var client = new HttpClient();
                var result = await client.GetAsync(url);
                // Kolekcje
                var list = new List<string>();
                var slownik = new Dictionary<string, int>();

                //Threadpool() - zestaw wiecznie otwartych watkow
                if (result.IsSuccessStatusCode) // 2xx
                {
                    string html = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(html);
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                    var matches = regex.Matches(html);
                    foreach (var m in matches)
                    {
                        Console.WriteLine(m);
                    }
                }
            }
            catch(Exception exc)
            {
                string blad = string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine("wystapil blad" + exc.ToString());
            }
            Console.WriteLine("KONIEC!");
        }
    }
}
