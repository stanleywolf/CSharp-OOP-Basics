using System;
using System.Collections.Generic;
using System.Text;

public class Power:Hardware
{
    public Power(string name, int maxCapacity, int maxMemory) : base(name, maxCapacity-(maxCapacity*3)/4, maxMemory+(maxMemory*3)/4)
    {
    }
}