using System;
using System.Collections.Generic;
using System.Text;

public class Light:Software
{
    public Light(string name, int consumCapacity, int consumMemory) : base(name, consumCapacity+ (consumCapacity* 2/4), consumMemory-(consumMemory*2/ 4))
    {
    }
}