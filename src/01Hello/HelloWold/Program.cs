using Akka.Actor;
using HelloWold;

ActorSystem actorSystem = ActorSystem.Create("system-actor");
IActorRef actor = actorSystem.ActorOf(Props.Create<NotificationActor>(), "notification-actor");

actor.Tell("Hello world");

Console.ReadLine();