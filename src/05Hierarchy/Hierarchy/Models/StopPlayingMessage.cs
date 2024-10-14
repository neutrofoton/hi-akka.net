using System;

namespace Hierarchy.Models;

public class StopPlayingMessage
{
    public StopPlayingMessage(string user)
    {
        User = user;
    }
    public string User { get; }
}
