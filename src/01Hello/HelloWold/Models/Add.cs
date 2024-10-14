using System;

namespace HelloWold.Models;

public class Add
{
    public Add(double term1, double term2)
    {
        Term1 = term1;
        Term2 = term2;
    }

    public double Term1 { get; private set;}
    public double Term2 { get; private set;}
}
