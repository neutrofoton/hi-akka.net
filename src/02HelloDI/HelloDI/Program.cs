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

actor.Tell("Hello there!");

Console.ReadLine();
actorSystem.Stop(actor);

Console.Read();