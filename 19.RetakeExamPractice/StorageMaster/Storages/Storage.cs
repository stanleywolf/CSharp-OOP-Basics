using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Products;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public abstract class Storage
    {
        public string Name { get; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public bool IsFull => this.products.Sum(c => c.Weight) >= this.Capacity;

        private readonly List<Product> products;
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        private readonly Vehicle[] garage;
        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.products = new List<Product>();
            this.garage = new Vehicle[garageSlots];

            this.InizializeGarage(vehicles);
        }

        private void InizializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var count = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[count] = vehicle;
                count++;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (this.garage.Length <= garageSlot)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.Garage.Any(c => c == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }
            this.garage[garageSlot] = null;

            var addedSlot = deliveryLocation.AddVeicle(vehicle);
            return addedSlot;
        }

        private int AddVeicle(Vehicle vehicle)
        {
            var freeSlotIndex = Array.IndexOf(this.garage, null);
            this.garage[freeSlotIndex] = vehicle;

            return freeSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProducts = 0;
            int counter = vehicle.Trunk.Count;
            for (int i = 0; i < counter; i++)
            {
                if (!vehicle.IsEmpty && !this.IsFull)
                {
                    this.products.Add(vehicle.Unload());
                    unloadedProducts++;
                }
            }

            return unloadedProducts;

        }

    }
}
