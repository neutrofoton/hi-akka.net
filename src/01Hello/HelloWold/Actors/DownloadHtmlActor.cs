using System;
using Akka.Actor;

namespace HelloWold.Actors;

public class DownloadHtmlActor : ReceiveActor
{
    public DownloadHtmlActor()
    {
        //ReceiveAsync<string>(async url => await GetPageHtmlAsync(url));
        ReceiveAnyAsync(async obj => await GetPageGenericAsync(obj));
    }
    private static async Task GetPageHtmlAsync(string url)
    {
         using var client = new HttpClient();
         var response = await client.GetAsync(url);
         var html = await response.Content.ReadAsStringAsync();

        Console.WriteLine("\n=====================================");
        Console.WriteLine($"Data for {url}");
        Console.WriteLine(html.Trim().Substring(0, 100));
    }
    private static async Task GetPageGenericAsync(object obj)
    {
        if (obj is string || obj is Uri)
        {
            await GetPageHtmlAsync(obj.ToString());
        }
        else
            throw new ArgumentNullException("Actor doesn't accept this kind of message");
    }
}

