using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;
            switch (type)
            {
                case "Van":
                    vehicle = new Van();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Semi":
                    vehicle = new Semi();
                    break;
                
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
            return vehicle;
        }
    }
}
