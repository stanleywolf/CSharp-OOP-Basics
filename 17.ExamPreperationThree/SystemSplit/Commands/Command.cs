using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command:ICommand
{
    public IList<string> Arguments { get; }

    public Command(IList<string> arguments)
    {
        Arguments = arguments;
    }

    public abstract string Execute();

}