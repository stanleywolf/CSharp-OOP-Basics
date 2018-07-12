using System;
using System.Collections.Generic;
using System.Text;

public interface ICommandInterpreter
{
    string ProcessCommand(IList<string> args);
}