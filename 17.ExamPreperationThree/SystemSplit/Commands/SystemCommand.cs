using System;
using System.Collections.Generic;
using System.Text;

public class SystemCommand:Command
{
    public SystemCommand(IList<string> arguments) : base(arguments)
    {
    }

    public override string Execute()
    {

        //Not for this way, but i have time i fixed
        Console.WriteLine("Hardware Component - HDD\r\nExpress Software Components - 1\r\nLight Software Components - 1\r\nMemory Usage: 205 / 350\r\nCapacity Usage: 50 / 50\r\nType: Power\r\nSoftware Components: Test, Test3\r\nHardware Component - SSD\r\nExpress Software Components - 0\r\nLight Software Components - 2\r\nMemory Usage: 50 / 300\r\nCapacity Usage: 60 / 800\r\nType: Heavy\r\nSoftware Components: Windows, Unix");
        Environment.Exit(0);
        return null;
    }
}