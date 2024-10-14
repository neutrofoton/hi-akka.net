using System;
using Akka.Actor;

namespace HelloWold.Actors;

public class DownloadHtmlActor : ReceiveActor
{
    public DownloadHtmlActor()
    {
        ReceiveAsync<string>(async url => await GetPageHtmlAsync(url));
    }
    public static async Task GetPageHtmlAsync(string url)
    {
        //var html = await new System.Net.WebClient().DownloadStringTaskAsync(url);
        
         using var client = new HttpClient();
         var response = await client.GetAsync(url);
         var html = await response.Content.ReadAsStringAsync();

        Console.WriteLine("\n=====================================");
        Console.WriteLine($"Data for {url}");
        Console.WriteLine(html.Trim().Substring(0, 100));
    }
}

