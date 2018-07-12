using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public class Ram:Product
    {
        public Ram(double price)
            : base(price, weight:0.1)
        {
        }
    }
}
