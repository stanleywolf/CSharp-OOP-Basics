using System;
using System.Collections.Generic;
using System.Text;

public class RegisterExpressSoftwareCommand:Command
{
    private IController controller;
    public RegisterExpressSoftwareCommand(IList<string> arguments, IController controller) : base(arguments)
    {
        this.controller = controller;
    }

    public override string Execute()
    {
        this.controller.RegisterExpressSoftware(this.Arguments);
        return null;
    }
}
