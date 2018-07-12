using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HardwareFactory:IHardwareFactory
{
    public IHardware CreateHardware(IList<string> args, string type)
    {
        var name = args[0];
        var capacity = int.Parse(args[1]);
        var memory = int.Parse(args[1]);

        Type hardType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name == type);
        return (IHardware) Activator.CreateInstance(hardType, name, capacity, memory);
    }
}