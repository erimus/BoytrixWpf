using System;
using System.Windows;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.UI.Common.Utilities;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Platform.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public interface IViewSelector
    {
    }

    public class ViewSelector : IViewSelector
    {
        private IUnityContainer container;
        private IRegionManager regionManager;

        public ViewSelector(IUnityContainer container,IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }
        public void OnNavigation(NavigationMessage navigationMessage)
        {
            
            if (navigationMessage == null)
            {
                throw new SystemException();
            }
           
            var region = regionManager.Regions[RegionNames.WorkspaceRegion];

            switch (navigationMessage.PageTitles)
            {
                case PageTitle.AddUser:
                    ViewShower<AddUser>.ShowView(region, container);
                    break;
                case PageTitle.UserAdmin:
                    ViewShower<UserAdmin>.ShowView(region, container);
                    break;
                case PageTitle.AddGroup:
                    ViewShower<AddGroup>.ShowView(region, container);
                    break;
                case PageTitle.ShippingMethodGridView:
                    ViewShower<ShippingMethodGridView>.ShowView(region, container);
                    break;
                case PageTitle.AddShippingMethod:
                    ViewShower<ShippingMethodDetail>.ShowView(region, container);
                    break;
                case PageTitle.OpenOrders:
                    ViewShower<OpenOrders>.ShowView(region, container);
                    break;
                    
                case PageTitle.HomePage:
                   
                    break;
                case PageTitle.MetricsPage:
                    break;
                case PageTitle.SettingsPage:
                    break;
                case PageTitle.SecurityPage:
                    break;
                case PageTitle.RestorePage:
                    
                    break;
            }

            //MessageBox.Show("public class ViewSelector: No View type defined");
        }
    }
}
