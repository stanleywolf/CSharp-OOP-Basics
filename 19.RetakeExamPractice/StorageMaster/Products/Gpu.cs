using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
    public class Gpu:Product
    {
        public Gpu(double price) 
            : base(price, weight:0.7)
        {
        }
    }
}
