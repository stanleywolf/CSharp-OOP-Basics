using System;
using System.Collections.Generic;
using System.Text;

public interface ICommand
{
    IList<string> Arguments { get; }
    string Execute();
}