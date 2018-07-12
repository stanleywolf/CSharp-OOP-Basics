using System;
using System.Collections.Generic;
using System.Text;

public class RegisterLightSoftwareCommand:Command
{
    private IController controller;
    public RegisterLightSoftwareCommand(IList<string> arguments, IController controller) : base(arguments)
    {
        this.controller = controller;
    }

    public override string Execute()
    {
        this.controller.RegisterLightSoftware(this.Arguments);
        return null;
    }
}
