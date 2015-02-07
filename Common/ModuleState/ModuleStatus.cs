using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common.ModuleState
{
    public enum ModuleStatus
    {
        Warehouse,
        Supplier,
        Inventory,
        Purchasing,
        Product,
        Order
    }

    public interface IModuleState
    {
        bool CanWarehouse(ModuleContext order);
        void Warehouse(ModuleContext order);
        bool CanSupplier(ModuleContext order);
        void Supplier(ModuleContext order);
        bool CanInventory(ModuleContext order);
        void Inventory(ModuleContext order);
        bool CanPurchasing(ModuleContext order);
        void Purchasing(ModuleContext order);
        bool CanProduct(ModuleContext order);
        void Product(ModuleContext order);
        bool CanOrder(ModuleContext order);
        void Order(ModuleContext order);
        ModuleStatus Status { get; }
    }

    public class ModuleContext
    {
        private IModuleState _moduleState;
        public ModuleContext( IModuleState moduleState)
        {
            _moduleState = moduleState;
        }
        private void Change(IModuleState moduleState)
        {
            _moduleState = moduleState;
        }
        public ModuleStatus Status
        {
            get { return _moduleState.Status; }
        }
        public bool CanWarehouse()
        {
            return _moduleState.CanWarehouse(this);
        }

        public void Warehouse()
        {
            if (CanWarehouse())
                _moduleState.Warehouse(this);
        }

        public bool CanSupplier()
        {
            return _moduleState.CanSupplier(this);
        }

        public void Supplier()
        {
            if (CanSupplier())
                _moduleState.Supplier(this);
        }

        public bool CanInventory()
        {
            return _moduleState.CanInventory(this);
        }

        public void Inventory()
        {
            if (CanInventory())
                _moduleState.Inventory(this);
        }

        public bool CanPurchasing()
        {
            return _moduleState.CanPurchasing(this);
        }

        public void Purchasing()
        {
            if (CanPurchasing())
                _moduleState.Purchasing(this);
        }

        public bool CanProduct()
        {
            return _moduleState.CanProduct(this);
        }

        public void Product()
        {
            if (CanProduct())
                _moduleState.Product(this);
        }

        public bool CanOrder()
        {
            return _moduleState.CanOrder(this);
        }

        public void Order()
        {
            if (CanOrder())
                _moduleState.Order(this);
        }
    }
}
