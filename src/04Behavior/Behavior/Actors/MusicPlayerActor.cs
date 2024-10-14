using System;
using Akka.Actor;
using Behavior.Models;

namespace Behavior.Actors;

public class MusicPlayerActor : ReceiveActor
{
    protected string CurrentSong;
    public MusicPlayerActor()
    {
        StoppedBehavior();
    }

    /// <summary>
    /// The behavior used while the player is stopped.
    /// </summary>
    private void StoppedBehavior()
    {
        Receive<PlaySongMessage>(m => PlaySong(m.Song));
        Receive<StopPlayingMessage>(m => Console.WriteLine("Cannot stop, the actor is already stopped"));
    }

    /// <summary>
    /// The behavior used while the song is playing.
    /// </summary>
    private void PlayingBehavior()
    {
        Receive<PlaySongMessage>(m => Console.WriteLine($"Cannot play. Currently playing '{CurrentSong}'"));
        Receive<StopPlayingMessage>(m => StopPlaying());
    }

    private void PlaySong(string song)
    {
        CurrentSong = song;
        Console.WriteLine($"Currently playing '{CurrentSong}'");

        //switch to play behavior
        Become(PlayingBehavior);
    }
    private void StopPlaying()
    {
        CurrentSong = null;
        Console.WriteLine($"Player is currently stopped.");

        //switch to stop behavior
        Become(StoppedBehavior);
    }
}
 