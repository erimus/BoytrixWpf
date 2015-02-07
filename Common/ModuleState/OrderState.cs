using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common.ModuleState
{
    public class OrderState:IModuleState
    {
        public bool CanWarehouse(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Warehouse(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanSupplier(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Supplier(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanInventory(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Inventory(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanPurchasing(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Purchasing(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanProduct(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Product(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanOrder(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public void Order(ModuleContext order)
        {
            throw new NotImplementedException();
        }

        public ModuleStatus Status
        {
            get { return ModuleStatus.Order; }
        }
    }
}
