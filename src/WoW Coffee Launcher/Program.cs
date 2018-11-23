using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Web;
using System.Net;
using System.Threading;

namespace WoW_Coffee_Launcher
{
    class Program
    {
        public const string url = "https://raw.githubusercontent.com/GreenPotionDevelopement/wow-Coffee/master/version.json";

        public class Patch
        {
            [JsonProperty("ver")]
            public string version { get; set; }

            [JsonProperty("patches")]
            public List<string> Patches { get; set; }
        }

        static void Main(string[] args)
        {
            Console.Title = "Retrieving Information..";
            Thread th = new Thread(async() =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string json_raw = await wc.DownloadStringTaskAsync(new Uri(url));
                        Patch json = JsonConvert.DeserializeObject<Patch>(json_raw);
                        PatchLoaded(json);
                    }
                    catch
                    s
                        Environment.Exit(-1);
                    }
                }
            });
            th.Start();

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }
        }

        static void PatchLoaded(Patch Config)
        {
            Console.Title = string.Format("WoW Coffee Launcher - v.{0}", Config.version);
            foreach (var ptch in Config.Patches)
            {
                Console.WriteLine(ptch);
            }
        }
    }
}
