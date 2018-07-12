using System;
using StorageMaster.Data;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
