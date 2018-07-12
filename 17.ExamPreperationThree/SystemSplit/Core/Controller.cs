using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Controller:IController
{
    private IList<IHardware> hardwares;
    private IHardwareFactory hardwareFactory;
    private ISoftwareFactory softwareFactory;

    public Controller(IList<IHardware> hardwares, IList<ISoftware> softwares, IHardwareFactory hardwareFactory, ISoftwareFactory softwareFactory)
    {
        this.hardwares = hardwares;

        this.hardwareFactory = hardwareFactory;
        this.softwareFactory = softwareFactory;
    }

    public void RegisterPowerHardware(IList<string> data)
    {

        IHardware hardware = hardwareFactory.CreateHardware(data, "Power");
        this.hardwares.Add(hardware);
    }
    public void RegisterHeavyHardware(IList<string> data)
    {
        IHardware hardware = hardwareFactory.CreateHardware(data, "Heavy");
        
        this.hardwares.Add(hardware);
    }

    public void RegisterExpressSoftware(IList<string> data)
    {
        IHardware hardware = this.hardwares.FirstOrDefault(h => h.Name == data[0]);
        if (hardware == null)
        {

        }
        var isValid = ValidateSoftware(data);
        if (isValid)
        {
            ISoftware software = softwareFactory.CreateSoftware(data.Skip(1).ToList(), "Express");
            hardware.AddSoftware(data[0], software);
        }
    }
    public void RegisterLightSoftware(IList<string> data)
    {
        IHardware hardware = this.hardwares.FirstOrDefault(h => h.Name == data[0]);
        if (hardware == null)
        {
            
        }
        var isValid = ValidateSoftware(data);
        if (isValid)
        {
            ISoftware software = softwareFactory.CreateSoftware(data.Skip(1).ToList(), "Light");
            hardware.AddSoftware(data[0], software); 
        }
    }

    private bool ValidateSoftware(IList<string> data)
    {
        IHardware hardware = this.hardwares.FirstOrDefault(h => h.Name == data[0]);
        
        if (this.hardwares.Any(f => f.Name==data[0]))
        {
            return true;
        }
        return false;
    }

    public void ReleaseSoftwareComponent(IList<string> data)
    {
        IHardware hardware = this.hardwares.FirstOrDefault(h => h.Name == data[0]);

        if (hardware != null)
        {
            hardware.RemoveSoftware(data[0],data[1]);
        }

    }

    public string AnalyzeHardware(IList<string> arguments)
    {
        var sb = new StringBuilder();
        var softwareCount = 0;
        var totalOperationalMemoryInUse = 0;
        var maximumMemory = 0;
        var totalCapacityTaken = 0;
        var maximumCapacity = 0;

        foreach (var hard in hardwares)
        {
            softwareCount += hard.AllSoftwares.Count;

            maximumMemory += hard.MaxMemory;
            totalOperationalMemoryInUse += hard.AllSoftwares.Sum(c => c.ConsumMemory);

            maximumCapacity += hard.MaxCapacity;
            totalCapacityTaken += hard.AllSoftwares.Sum(c => c.ConsumCapacity);
        }

        sb.AppendLine("System Analysis");
        sb.AppendLine($"Hardware Components: {this.hardwares.Count}");
        sb.AppendLine($"Software Components: {softwareCount}");
        sb.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");
        sb.AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

        return sb.ToString().TrimEnd();
    }
}