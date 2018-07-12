using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class SoftwareFactory:ISoftwareFactory
    {
        public ISoftware CreateSoftware(IList<string> args, string type)
        {
        var name = args[0];
            var capacity = int.Parse(args[1]);
            var memory = int.Parse(args[2]);

            Type hardType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name == type);
            return (ISoftware)Activator.CreateInstance(hardType, name, capacity, memory);
    }
    }
   