using System.Windows;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities;
using Microsoft.Practices.Prism.Commands;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public class NavigationViewModel
    {
        public ICommand NavigateCommand
        {
            get
            {
                return new DelegateCommand<object>(OnNavigate);
            }
        }

        private void OnNavigate(object view)
        {
            NavigationService.NavigateTo(RegionNames.MainContentRegion, view as FrameworkElement);
        }
    }
}
