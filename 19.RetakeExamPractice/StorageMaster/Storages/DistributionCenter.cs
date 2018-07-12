using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
   public  class DistributionCenter:Storage
    {
        public DistributionCenter(string name) : base(name, capacity: 2, garageSlots: 5, vehicles: new Vehicle[] { new Van(), new Van(), new Van() })
        {
        }
    }
}
