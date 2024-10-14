using System;

namespace HelloWold.Models;

public class Answer
{
    public Answer(double value)
    {
        Value = value;
    }
    public double Value { get; private set; }
}
