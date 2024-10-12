using Akka.Actor;
using HelloWold;

ActorSystem systemActor = ActorSystem.Create("system-actor");

//Props prop = Props.Create(()=>new NotificationActor());

//IActorRef notificationActor = systemActor.ActorOf(Props.Create<NotificationActor>(), "notification-actor");
IActorRef notificationActor = systemActor.ActorOf<NotificationActor>("notification-actor");

notificationActor.Tell("Hello world");

Console.ReadLine();