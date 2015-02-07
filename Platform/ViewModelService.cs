using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.WPF.Libraries.Base;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform
{
    public interface IViewModelService
    {
    }

    public class ViewModelService<T> : IViewModelService where T : class
    {
        public IEventAggregator EventAggregator { get; set; }
        public IUnityContainer Container { get; set; }
        public RepositoryBase<T> Repository { get; set; }

        public IViewService ViewService { get; set; }

      
    }
}
