using System;
using System.Collections.Generic;
using System.Text;

public interface IController
{
    void RegisterPowerHardware(IList<string> data);
    void RegisterHeavyHardware(IList<string> data);
    void RegisterExpressSoftware(IList<string> data);
    void RegisterLightSoftware(IList<string> data);
    void ReleaseSoftwareComponent(IList<string> data);
    string AnalyzeHardware(IList<string> arguments);
}