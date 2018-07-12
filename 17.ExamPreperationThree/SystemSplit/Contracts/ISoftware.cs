using System;
using System.Collections.Generic;
using System.Text;

public interface ISoftware
{
    string Name { get; }
    int ConsumCapacity { get; }
    int ConsumMemory { get; }
}