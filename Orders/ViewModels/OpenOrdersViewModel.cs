using System;
using System.Collections.Specialized;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.SearchState.OrderState;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataAccess.Repository;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Base;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.BoytrixModules.Order.ViewModels
{
    public class OpenOrdersViewModel : VmBase<Logic.DataTransfer.Model.Order>
    {
        private OpenOrderRepository _repository;
        public OpenOrdersViewModel(OpenOrderRepository repository)
            : base(repository)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<SearchModeArgsEvent>().Subscribe(DoSearch);
            _repository = repository;
        }

        private void DoSearch(SearchModeArgs obj)
        {
          

            _repository.GetModelData((o,e) =>
            {
                
            });
        }

        protected override void DoSearchDb(SearchModeArgs obj)
        {
           
        }
        protected override void ValidateCollection(NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override bool DataStoreContainsDuplicates()
        {
            throw new NotImplementedException();
        }

        protected override bool VmDataContainsDuplicates()
        {
            throw new NotImplementedException();
        }

        protected override void LoadData()
        {
            throw new NotImplementedException();
        }

        protected override void ReLoadData()
        {
            throw new NotImplementedException();
        }

        protected override void ReFreshDataContext()
        {
            throw new NotImplementedException();
        }

        protected override void DoLongRunningProcess(string searchValue)
        {
            throw new NotImplementedException();
        }

        protected override void DoWork(string searchValue)
        {
            throw new NotImplementedException();
        }

        protected override void SaveToRepository(VmOnSave obj)
        {
            throw new NotImplementedException();
        }

    
    }
}
