using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
   public class HardDrive:Product
    {
        public HardDrive(double price)
            : base(price, weight:1.0)
        {
        }
    }
}
