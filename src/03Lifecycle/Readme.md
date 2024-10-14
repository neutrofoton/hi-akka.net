```csharp
protected virtual void PreRestart(Exception reason, object message)
{
    ActorBase
        .Context
        .GetChildren()
        .ToList<IActorRef>()
        .ForEach((Action<IActorRef>)(c =>
        {
            ActorBase.Context.Unwatch(c);
            ActorBase.Context.Stop(c);
        }));

    this.PostStop();
}
```