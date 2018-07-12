using System;
using System.Collections.Generic;
using System.Text;

public class RegisterHeavyHardwareCommand:Command
{
    private IController controller;
    public RegisterHeavyHardwareCommand(IList<string> arguments, IController controller) : base(arguments)
    {
        this.controller = controller;
    }

    public override string Execute()
    {
        this.controller.RegisterHeavyHardware(this.Arguments);
        return null;
    }
}