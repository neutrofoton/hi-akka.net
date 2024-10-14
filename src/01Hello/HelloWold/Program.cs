using Akka.Actor;
using HelloWold;
using HelloWold.Actors;
using HelloWold.Models;

ActorSystem systemActor = ActorSystem.Create("system-actor");

//Props prop = Props.Create(()=>new NotificationActor());

Console.WriteLine("--------- demo tell --------------------------");
//IActorRef notificationActor = systemActor.ActorOf(Props.Create<NotificationActor>(), "notification-actor");
IActorRef notificationActor = systemActor.ActorOf<NotificationActor>("notification-actor");
notificationActor.Tell("Hello world");


IActorRef greetingActor = systemActor.ActorOf<GreetingActor>("greeting-actor");
greetingActor.Tell("hello");
greetingActor.Tell(new GreetingMessage("salam"));

Thread.Sleep(2000);
Console.WriteLine("--------- demo ask --------------------------");

IActorRef calculator = systemActor.ActorOf<CalculatorActor>("calculator");
Answer result = calculator.Ask<Answer>(new Add(1,2)).Result;
Console.WriteLine("Addition result: " + result.Value);

Thread.Sleep(2000);
Console.WriteLine("--------- demo actor async--------------------------");

IActorRef htmlDownloaderActor = systemActor.ActorOf<DownloadHtmlActor>("html-downloader-actor");
//htmlDownloaderActor.Tell("https://www.microsoft.com");
htmlDownloaderActor.Tell(new Uri("https://www.microsoft.com"));

Thread.Sleep(2000);
Console.WriteLine("--------- end --------------------------");

Console.ReadLine();

systemActor.Terminate();