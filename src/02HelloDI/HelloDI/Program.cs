using System.Text;
using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using HelloDI.Actors;
using HelloDI.Services;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddSingleton<IEmailService, EmailService>();

collection.AddScoped<NotificationActor>();
collection.AddScoped<WhatsappNotificationActor>();

var provider = collection.BuildServiceProvider();

//Akka actor definition
using var actorSystem = ActorSystem.Create("system-actor");
actorSystem.UseServiceProvider(provider);

var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>(), "notification-actor");

Thread.Sleep(1000);

string options=new StringBuilder()
    .AppendLine("Enter message (with following option demonstration):")
    .AppendLine("1.  n : generating NullReferenceException => Restart Actor")
    .AppendLine("2.  a : generating ArgumentException => Resume Actor")
    .AppendLine("3.  {empty} : generating ArgumentException => Stop Actor")
    .AppendLine("4.  q : terminate application")
    .ToString();


string choice = "Your choice : ";
while(true)
{
    Console.WriteLine(options);

    Console.Write(choice);
    string? message = Console.ReadLine();
    if("q".Equals(message, StringComparison.OrdinalIgnoreCase)) break;

    actor.Tell(message);

    Console.WriteLine();
    Thread.Sleep(1000);
}


actorSystem.Stop(actor);
