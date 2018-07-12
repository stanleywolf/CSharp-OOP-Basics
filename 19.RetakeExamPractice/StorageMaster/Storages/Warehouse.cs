using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class Warehouse:Storage
    {
        public Warehouse(string name) 
            : base(name, capacity: 10, garageSlots: 10, vehicles: new Vehicle[] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
