using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enumerable = System.Linq.Enumerable;

public abstract class Hardware:IHardware
{
    public string Name { get; private set; }
    public int MaxCapacity { get; private set; }
    public int MaxMemory { get; private set; }
    private IList<ISoftware> allSoftwares;
    public IList<ISoftware> AllSoftwares
    {
        get { return this.allSoftwares; }
    }
    
    public Hardware(string name ,int maxCapacity ,int maxMemory)
    {
        this.Name = name;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.allSoftwares = new List<ISoftware>();
    }
    public void RemoveSoftware(string hard, string soft)
    {
        ISoftware software = this.allSoftwares.First(c => c.Name == soft);
        this.AllSoftwares.Remove(software);
    }

    public void AddSoftware(string data, ISoftware software)
    {
        if (this.MaxCapacity >= software.ConsumCapacity + this.AllSoftwares.Sum(c => c.ConsumCapacity))
        {
            this.allSoftwares.Add(software);
        }
    }
}