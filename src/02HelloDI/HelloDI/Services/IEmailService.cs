using System;

namespace HelloDI.Services;

public interface IEmailService
{
    void Send(string message);
}
