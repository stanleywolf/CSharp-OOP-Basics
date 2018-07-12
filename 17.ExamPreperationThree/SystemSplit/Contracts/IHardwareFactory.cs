using System;
using System.Collections.Generic;
using System.Text;

public interface IHardwareFactory
{
    IHardware CreateHardware(IList<string> args, string type);
}