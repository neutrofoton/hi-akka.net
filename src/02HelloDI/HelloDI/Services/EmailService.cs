using System;

namespace HelloDI.Services;

public class EmailService : IEmailService
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email with message: {message}");
    }
}
