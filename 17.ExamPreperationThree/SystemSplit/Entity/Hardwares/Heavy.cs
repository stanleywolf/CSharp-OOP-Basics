using System;
using System.Collections.Generic;
using System.Text;

public class Heavy:Hardware
{
    public Heavy(string name,  int maxCapacity, int maxMemory) : base(name, maxCapacity * 2, maxMemory-(maxMemory/4))
    {
    }
}
