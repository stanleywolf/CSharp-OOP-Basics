using System;
using System.Collections.Generic;
using System.Text;

public class Software : ISoftware
{
    public string Name { get; private set; }
    public int ConsumCapacity { get; private set; }
    public int ConsumMemory { get; private set; }

    public Software(string name, int consumCapacity, int consumMemory)
    {
        this.Name = name;
        this.ConsumCapacity = consumCapacity;
        this.ConsumMemory = consumMemory;
    }
}
   
