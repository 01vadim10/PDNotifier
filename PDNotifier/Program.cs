using PDNotifier.Models;
using PDNotifier.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PDNotifier
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Read data from remote source
            var data = await ReadDataAsync();
            //Try to convert data to our TheKing class
            var kings = JsonSerializer.Deserialize<List<TheKing>>(data);
            //Find answers on the questions
            var (king, yearsOfReign) = kings.KingRuledLonger();
            var popularName = kings.FindTheMostCommonName();

            var dashboard = new Dashboard();
            var policeman = new PolicemanNotifier("NYPD");
            var policeman2 = new PolicemanNotifier("K-9");

            dashboard.OnChange += (sender, e) => policeman.Handle(sender, e);
            dashboard.Notify($"Interesting facts about United Kingdom kings...");
            dashboard.Notify($"{king?.Name} ruled the longest period - {yearsOfReign}");

            dashboard.OnChange += (sender, e) => policeman2.Handle(sender, e);
            dashboard.Notify($"The most common first name for king was {popularName}");
        }

        //Read data asynchronously to allow main thread work further while we are reading
        private static async Task<string> ReadDataAsync()
        {
            var url = new Uri("https://gist.githubusercontent.com/christianpanton/10d65ccef9f29de3acd49d97ed423736/raw/b09563bc0c4b318132c7a738e679d4f984ef0048/kings");
            using var client = new WebClient();

            return await client.DownloadStringTaskAsync(url);
        }
    }
}
