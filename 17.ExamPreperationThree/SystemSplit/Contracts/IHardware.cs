using System;
using System.Collections.Generic;
using System.Text;

public interface IHardware
{
    string Name { get; }
    int MaxCapacity { get; }
    int MaxMemory { get; }
    IList<ISoftware> AllSoftwares { get; }
    void RemoveSoftware(string hard, string soft);
    void AddSoftware(string s,ISoftware software);
}