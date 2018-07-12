using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Factories;
using StorageMaster.Products;
using StorageMaster.Storages;
using StorageMaster.Vehicles;

namespace StorageMaster.Data
{
    public class StorageMaster
    {
        private Dictionary<string,Storage> storageRegistry;
        private Dictionary<string, Stack<Product>> productPool;
        private Vehicle currentVehicle;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.storageFactory = new StorageFactory();
            this.productFactory = new ProductFactory();

            this.storageRegistry = new Dictionary<string, Storage>();
            this.productPool = new Dictionary<string, Stack<Product>>();
        }


        public string AddProduct(string type, double price)
        {

            if (!productPool.ContainsKey(type))
            {
                productPool.Add(type,new Stack<Product>());
            }
            Product product = productFactory.CreateProduct(type, price);
            productPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);


            storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";

        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry[storageName];
            this.currentVehicle = storage.GetVehicle(garageSlot);
            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            Vehicle vehicle = this.currentVehicle;

            
            int loadedProducts = 0;

            foreach (var productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }
                if (!productPool.ContainsKey(productName)
                    || !this.productPool[productName].Any())
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                    Product product = this.productPool[productName].Pop();
                this.currentVehicle.LoadProduct(product);
                loadedProducts++;
            }
            int productCount = productNames.Count();
            return $"Loaded {loadedProducts}/{productCount} products into {currentVehicle.GetType().Name}";

        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            Storage sourceStorage = storageRegistry[sourceName];
            Storage deliveryStorage = storageRegistry[destinationName];

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int freeGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, deliveryStorage);
            return $"Sent {vehicle.GetType().Name} to {deliveryStorage.Name} (slot {freeGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            
            int productsInVehicle = vehicle.Trunk.Count;
            
           int unloadedProductsCount=storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storageRegistry[storageName];
            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productCapacity = storage.Products.Sum(p => p.Weight);
            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]", productCapacity, storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(veh => veh?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));

            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var storage in storageRegistry.Values.OrderByDescending(c=>c.Products.Sum(s=>s.Price)))
            {
                sb.AppendLine($"{storage.Name}:" + Environment.NewLine +
                       $"Storage worth: ${storage.Products.Sum(c => c.Price):f2}");
            }
            return sb.ToString().Trim();
        }

    }
}
