using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSplit.Commands
{
    class AnalyzeCommand:Command
    {
        private IController controller;

        public AnalyzeCommand(IList<string> arguments, IController controller) : base(arguments)
        {
            this.controller = controller;
        }

        public override string Execute()
        {
            var result = this.controller.AnalyzeHardware(this.Arguments);
            return result;
        }
    }
}
