using Akka.Actor;
using Behavior.Actors;
using Behavior.Models;

ActorSystem system = ActorSystem.Create("my-first-akka");
IActorRef musicPlayer = system.ActorOf<MusicPlayerActor>("musicPlayer");

musicPlayer.Tell(new PlaySongMessage("Song 1"));
musicPlayer.Tell(new PlaySongMessage("Song 2"));
musicPlayer.Tell(new StopPlayingMessage());
musicPlayer.Tell(new StopPlayingMessage());
musicPlayer.Tell(new PlaySongMessage("Song 2"));


Console.Read();
system.Terminate();
