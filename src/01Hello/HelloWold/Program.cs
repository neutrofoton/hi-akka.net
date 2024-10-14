using Akka.Actor;
using HelloWold;
using HelloWold.Actors;

ActorSystem systemActor = ActorSystem.Create("system-actor");

//Props prop = Props.Create(()=>new NotificationActor());

//IActorRef notificationActor = systemActor.ActorOf(Props.Create<NotificationActor>(), "notification-actor");
IActorRef notificationActor = systemActor.ActorOf<NotificationActor>("notification-actor");
notificationActor.Tell("Hello world");


IActorRef greetingActor = systemActor.ActorOf<GreetingActor>("greeting-actor");
greetingActor.Tell("salam");

IActorRef htmlDownloaderActor = systemActor.ActorOf<DownloadHtmlActor>("html-downloader-actor");
//htmlDownloaderActor.Tell("https://www.microsoft.com");
htmlDownloaderActor.Tell(new Uri("https://www.microsoft.com"));

Console.ReadLine();

systemActor.Terminate();