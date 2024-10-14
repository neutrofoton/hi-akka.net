using System;

namespace Behavior.Models;

public class PlaySongMessage
{
    public PlaySongMessage(string song)
    {
        Song = song;
    }
    public string Song { get; }
}