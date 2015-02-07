using Microsoft.Practices.Prism.Mvvm;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls.Search
{
    public class StandardSearchVm : BindableBase
    {
        private object _selectedItem;
        public object SelectedItem { get { return _selectedItem; } set { if (value != _selectedItem) { _selectedItem = value; OnPropertyChanged(() => SelectedItem); } } }

        private object _selectedValue;
        public object SelectedValue { get { return _selectedValue; } set { if (value != _selectedValue) { _selectedValue = value; OnPropertyChanged(() => SelectedValue); } } }

        private IIntelliboxResultsProvider _queryProvider;
        public IIntelliboxResultsProvider QueryProvider { get { return _queryProvider; } private set { if (value != _queryProvider) { _queryProvider = value; OnPropertyChanged(() => QueryProvider); } } }

        public StandardSearchVm(IIntelliboxResultsProvider provider)
        {
            QueryProvider = provider;
        }
    }
}
