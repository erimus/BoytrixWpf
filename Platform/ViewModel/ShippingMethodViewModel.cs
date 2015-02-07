using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Base.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class ShippingMethodViewModel : VmBase<ShippingMethod>, IPageViewModel
    {
        private OrderRepository repository;
        public ShippingMethodViewModel(OrderRepository repository)
            : base(repository)
        {

            this.repository = repository;
            GetShippingMethods();

        }


        protected override void ReFreshDataContext()
        {
            GetShippingMethods();
        }

        protected override void DoLongRunningProcess(string searchValue)
        {
            throw new NotImplementedException();
        }

        protected override void DoWork(string searchValue)
        {
            throw new NotImplementedException();
        }

        protected override void LoadData()
        {
            GetShippingMethods();
        }
        private void GetShippingMethods()
        {
            repository.GetShippingMethod((o) =>
            {
                 var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                 var data = container.Resolve<IEnumerable<ShippingMethod>>("ShippingMethod");
                VmData = new ObservableCollection<ShippingMethod>(data);
            });

        }



        private void Exit(int? obj)
        {

            // Broadcast an Event
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<CloseViewEvent>().Publish(new CloseViewMessage { ViewName = "ShippingMethodView" });

        }

        private void ExitEventHandler(CloseViewMessage msg)
        {
            if (ExitText == "Cancel")
            {
                LoadData();

            }
        }


        //protected override void AddToCollection(AddModeArgs obj)
        //{
        //    if (!repository.HasPendingCommits())
        //    {
        //        //park current collection into datastore

        //        repository.DataStore = VmData;
        //        VmData = CreateNewCollection();
                
        //    }
        //    var item = CreateNewITem();
        //    SelectedItem = item;
        //    VmData.Add(item);

        //    base.AddToCollection(obj);
           
        //}

        private void EditEventHandler()
        {
            throw new NotImplementedException();
        }




        #region Notifying Properties


        private string exitText;
        public string ExitText
        {
            get
            {
                return exitText;
            }

            set
            {
                if (exitText != value)
                    SetProperty(ref exitText, value);
            }
        }





        #endregion

        #region button Commands



        #endregion



        //protected override ObservableCollection<ShippingMethod> NewCollection()
        //{

        //    return new ObservableCollection<ShippingMethod>();
        //}

        //protected override ShippingMethod CreateNewITem()
        //{
        //    return new ShippingMethod();
        //}

        //protected override void EditCurrentRow()
        //{

        //    // Populate allTests with the full set of data
        //    //ObservableCollection<ShippingMethod> filtered;
        //    //var current = VmData.Where(t => (t.ShippingMethodName == SelectedItem.ShippingMethodName && t.Priority == SelectedItem.Priority));

        //    //GetRowForEditing(current);

        //    //filtered = new ObservableCollection<ShippingMethod>(current);
        //    //VmData = filtered;
        //}



        protected override void ValidateCollection(NotifyCollectionChangedEventArgs e)
        {


            //if (e.Action == NotifyCollectionChangedAction.Add ||
            //   e.Action == NotifyCollectionChangedAction.Replace)
            //{
            //    for (int i = 0; i < e.NewItems.Count; i++)
            //    {
            //        ShippingMethod item = e.NewItems[i] as ShippingMethod;

            //        if (VmData.Where(c => c.ShippingMethodName == item.ShippingMethodName).Count() > 1)
            //        {
            //            VmData.Remove(item);
            //            throw new ArgumentException("ShippingMethod cannot be duplicated.");
            //        }
            //    }
            //  }
        }


        protected override bool DataStoreContainsDuplicates()
        {

            return repository.DataStore==null?false:repository.DataStore.Where(c => c.ShippingMethodName == SelectedItem.ShippingMethodName).Any();
          
        }

        protected override bool VmDataContainsDuplicates()
        {
            return VmData == null ? false : VmData.Where(c => c.ShippingMethodName == SelectedItem.ShippingMethodName).Any(); 
        }



        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        protected override void ReLoadData()
        {
            throw new NotImplementedException();
        }

        protected override void SaveToRepository(VmOnSave obj)
        {
            //repository.SaveNoCommit(obj.Vmode, obj.GetRow<UserBasicInfo>());
        }
    }

}
