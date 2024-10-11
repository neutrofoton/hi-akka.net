using System;
using Akka.Actor;
using Akka.DI.Core;
using HelloDI.Services;

namespace HelloDI.Actors;

class NotificationActor : UntypedActor
{
    private readonly IEmailService emailService;
    private readonly IActorRef childActor;
    public NotificationActor(IEmailService emailService)
    {
        this.emailService = emailService;

        //instantiate child actor using Akka Context
        //this.childActor = Context.ActorOf(Props.Create<WhatsappNotificationActor>(), "whatsapp-actor");

        //instantiate child actor using DI
        this.childActor = Context.ActorOf(Context.System.DI().Props<WhatsappNotificationActor>());

        
    }
    protected override void OnReceive(object message)
    {
        Console.WriteLine($"Message received: {message}");
        emailService.Send(message?.ToString());
        childActor.Tell(message);
    }
    protected override SupervisorStrategy SupervisorStrategy()
    {
        return new OneForOneStrategy(
            maxNrOfRetries: 10,
            withinTimeRange: TimeSpan.FromMinutes(1),
            localOnlyDecider: ex =>
            {
                return ex switch
                {
                    ArgumentException ae => Directive.Resume,
                    NullReferenceException ne => Directive.Restart,
                    _ => Directive.Stop
                };
            }
            );
    }
    protected override void PreStart() => Console.WriteLine("Actor started");
    protected override void PostStop() => Console.WriteLine("Actor stopped");
}
