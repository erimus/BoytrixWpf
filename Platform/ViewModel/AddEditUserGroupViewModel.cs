﻿using System;
using System.Linq;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataAccess.Repository;
using Boytrix.Logic.DataTransfer.Model;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class AddEditUserGroupViewModel : DetailViewModelBase<UserGroup>
    {
        public AddEditUserGroupViewModel(IEventAggregator eventAggregator, IUnityContainer container,  IViewService viewService) 
            : base(eventAggregator, container,  viewService)
        {
            //[usp_GetGroupsXML]
        }
        //public bool KeepAlive
        //{
        //    get { return false; }
        //}
        protected override bool DataStoreContainsDuplicates(SaveModeArgs obj)
        {
            return VmData.Contains(obj.GetRow < UserGroup>());
        }


        protected override void SaveOtherObjectsPriorToVmData(SaveModeArgs obj)
        {
            
        }

        protected override void SaveOtherObjectsPostVmData(SaveModeArgs obj)
        {
            
        }

        protected override bool VmDataContainsDuplicates()
        {

            return false;
        }
        protected override void PreAddToCollection()
        {
            
        }

        protected override void PostAddToCollection()
        {
            
        }

        protected override void PreDeleteFromCollection()
        {
            throw new NotImplementedException();
        }

        protected override void PostDeleteFromCollection()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteItemFromCollection()
        {
            var itemToRemove = VmData.Single(x=>x.Name==SelectedItem.Name && x.Description==SelectedItem.Description);
            VmData.Remove(itemToRemove);
          
        }

        protected override void PreEditCollection()
        {
            
        }

        protected override void PostEditCollection()
        {
           
        }

        protected override void SelectRelatedRecords()
        {
            
        }

        protected override void ConfigureValidationRules()
        {
            
        }

        //private UserGroup _selectedItem;
        //public override UserGroup SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set
        //    {
        //        if (value != _selectedItem)
        //        {
        //            SetProperty(ref _selectedItem, value);
        //            SelectRelatedRecords();
        //        }
        //    }
        //}


    }
}
