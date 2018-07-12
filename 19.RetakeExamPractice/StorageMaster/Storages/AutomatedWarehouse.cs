using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class AutomatedWarehouse:Storage
    {
        public AutomatedWarehouse(string name) : base(name, capacity:1, garageSlots:2,vehicles:new Vehicle[]{new Truck()})
        {
        }
    }
}
