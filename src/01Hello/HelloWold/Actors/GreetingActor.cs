using System;
using Akka.Actor;
using HelloWold.Models;

namespace HelloWold.Actors;

public class GreetingActor: ReceiveActor
{
    public GreetingActor()
    {
        Receive<string>(message => HandleStringMessage(message));
        Receive<GreetingMessage>(greeting => HandleGreeting(greeting));
    }
    private void HandleStringMessage(string message)
    {
        Console.WriteLine(message);

    }

     private void HandleGreeting(GreetingMessage greeting)
    {
       
        Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
        Console.WriteLine($"Received a greeting: {greeting.Greeting}");
        Console.WriteLine($"Actor's path: {Self.Path}");
        Console.WriteLine($"Actor is part of the ActorSystem:{Context.System.Name}");
    }
}
