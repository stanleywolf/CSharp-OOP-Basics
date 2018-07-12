using System;
using System.Collections.Generic;
using System.Text;

public class ReleaseSoftwareComponentCommand : Command
{
    private IController controller;

    public ReleaseSoftwareComponentCommand(IList<string> arguments, IController controller) : base(arguments)
    {
        this.controller = controller;
    }

    public override string Execute()
    {
        this.controller.ReleaseSoftwareComponent(this.Arguments);
        return null;
    }
}
   