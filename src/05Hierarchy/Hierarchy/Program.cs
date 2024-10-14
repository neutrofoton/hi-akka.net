using Akka.Actor;
using Hierarchy.Actors;
using Hierarchy.Models;

ActorSystem system = ActorSystem.Create("my-first-akka");
IActorRef dispatcher = system.ActorOf<MusicPlayerCoordinatorActor>("player-coordinator");

dispatcher.Tell(new PlaySongMessage("Smoke on the water", "John"));
dispatcher.Tell(new PlaySongMessage("Another brick in the wall", "Mike"));

dispatcher.Tell(new StopPlayingMessage("John"));
dispatcher.Tell(new StopPlayingMessage("Mike"));
dispatcher.Tell(new StopPlayingMessage("Mike"));

Console.Read();
system.Terminate();