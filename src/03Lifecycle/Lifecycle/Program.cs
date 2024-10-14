using Akka.Actor;
using Lifecycle.Actors;
using Lifecycle.Models;

ActorSystem system = ActorSystem.Create("my-first-akka");

IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");
EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

emailSender.Tell(emailMessage);
emailSender.Tell(emailMessage);
emailSender.Tell(PoisonPill.Instance);
emailSender.Tell(emailMessage);

Thread.Sleep(1000);

await system.Terminate();

Console.Read();