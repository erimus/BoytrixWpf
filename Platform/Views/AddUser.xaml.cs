using System;
using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : IRegionMemberLifetime
    {
        public AddUser(AddUserViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            //var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            //this.DataContext = container.Resolve<UserAdminViewModel>();

        }


        public bool KeepAlive
        {
            get
            {
            
                return true;
            }
        }

    
    }
}
