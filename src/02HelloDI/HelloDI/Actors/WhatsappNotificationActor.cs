using System;
using Akka.Actor;

namespace HelloDI.Actors;

public class WhatsappNotificationActor: UntypedActor
{
    protected override void PreStart() => Console.WriteLine("WhatsappNotificationActor child stared!");
    protected override void PostStop() => Console.WriteLine("WhatsappNotificationActor child stopped!");
    protected override void OnReceive(object message)
    {
        if (message.ToString() == "n")
            throw new NullReferenceException();

        if (message.ToString() == "a")
            throw new ArgumentException();

        if (string.IsNullOrEmpty(message.ToString()))
            throw new Exception();

        Console.WriteLine($"Sending whatsapp message : {message}");
    }
}