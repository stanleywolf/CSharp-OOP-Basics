using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RegisterPowerHardwareCommand:Command
{
    private IController controller;
    public RegisterPowerHardwareCommand(IList<string> arguments, IController controller) : base(arguments)
    {
        this.controller = controller;
    }

    public override string Execute()
    {
       this.controller.RegisterPowerHardware(this.Arguments);
        return null;
    }
}