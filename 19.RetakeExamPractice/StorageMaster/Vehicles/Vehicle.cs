using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Products;

namespace StorageMaster.Vehicles
{
    public abstract class Vehicle
    {
        public int Capacity { get; private set; }

        private readonly List<Product> trunk;
        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public bool IsFull => this.trunk.Sum(c => c.Weight) >= this.Capacity;
        public bool IsEmpty => !this.trunk.Any();

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }


        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No product left in vehicle!");
            }
            Product lastProduct = this.trunk.Last();
            int lastProductIndex = this.trunk.Count - 1;
            this.trunk.RemoveAt(lastProductIndex);
            return lastProduct;
        }
    }
}
