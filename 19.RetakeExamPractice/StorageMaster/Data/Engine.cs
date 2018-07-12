using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Data
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return;
                }
                try
                {
                    var commandArgs = input.Split();
                    var command = commandArgs[0];
                    var tokens = commandArgs.Skip(1).ToArray();

                    var result = string.Empty;
                    switch (command)
                    {
                        case "AddProduct":
                            result = storageMaster.AddProduct(tokens[0], double.Parse(tokens[1]));
                            break;
                        case "RegisterStorage":
                            result = storageMaster.RegisterStorage(tokens[0], tokens[1]);
                            break;
                        case "SelectVehicle":
                            result = storageMaster.SelectVehicle(tokens[0],int.Parse(tokens[1]));
                            break;
                        case "LoadVehicle":
                            result = storageMaster.LoadVehicle(tokens);
                            break;
                        case "SendVehicleTo":
                            result = storageMaster.SendVehicleTo(tokens[0],int.Parse(tokens[1]),tokens[2]);
                            break;
                        case "UnloadVehicle":
                            result = storageMaster.UnloadVehicle(tokens[0], int.Parse(tokens[1]));
                            break;
                        case "GetStorageStatus":
                            result = storageMaster.GetStorageStatus(tokens[0]);
                            break;
                    }

                    Console.WriteLine(result);

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
