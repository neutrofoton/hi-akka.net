using System;
using Akka.Actor;

namespace HelloWold.Actors;

public class GreetingActor: ReceiveActor
{
    public GreetingActor()
    {
        Receive<string>(message => HandleStringMessage(message));
    }
    private void HandleStringMessage(string message)
    {
        Console.WriteLine(message);
    }
}
