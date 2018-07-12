using System;
using System.Collections.Generic;
using System.Text;

public interface ISoftwareFactory
{
    ISoftware CreateSoftware(IList<string> args,string type);
}
