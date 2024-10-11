using System;
using Akka.Actor;

namespace HelloWold;

class NotificationActor : UntypedActor
{
    protected override void OnReceive(object message)
    {
        Console.WriteLine($"Message received : {message}");
    }

    protected override void PreStart() => Console.WriteLine("Actor started");

    protected override void PostStop() => Console.WriteLine("Actor stopped");
}