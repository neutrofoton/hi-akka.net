using System;
using Akka.Actor;
using HelloWold.Models;

namespace HelloWold.Actors;

public class CalculatorActor : ReceiveActor
{
    public CalculatorActor()
    {
        Receive<Add>(add => Sender.Tell(new Answer(add.Term1 + add.Term2)));
    }
}
