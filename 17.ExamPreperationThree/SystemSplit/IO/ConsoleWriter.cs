using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleWriter:IWriter
{
    public void WriteLine(string data)
    {
        Console.WriteLine(data);
    }
}