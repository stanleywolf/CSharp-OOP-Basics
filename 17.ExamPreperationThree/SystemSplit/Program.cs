using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        var softwares = new List<ISoftware>();
        var hardwares = new List<IHardware>();

        var hadrwareFactory = new HardwareFactory();
        var softwareFactory = new SoftwareFactory();

        IController controller = new Controller(hardwares,softwares,hadrwareFactory,softwareFactory);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(controller);

        IEngine engine = new Engine(reader,writer,commandInterpreter);
        engine.Run();
    }
}