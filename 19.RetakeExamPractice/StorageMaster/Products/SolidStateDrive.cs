using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public class SolidStateDrive:Product
    {
        public SolidStateDrive(double price) 
            : base(price, weight:0.2)
        {
        }
    }
}
