//using Boytrix.UI.WPF.BoytrixModules.Login.DataServices;
//using Microsoft.Practices.Prism.Mvvm;
//using Microsoft.Practices.Prism.PubSubEvents;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.UI.WPF.BoytrixModules.Login.ViewModels
//{
//    public class LoginViewModel:BindableBase
//    {
//         private IUserDataService m_dataService;
//        private readonly IEventAggregator eventAggregator;

//        public LoginViewModel(IUserDataService dataService, IEventAggregator eventAggregator)
//        {

//            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");
//            this.eventAggregator = eventAggregator;

//            if (dataService == null) throw new ArgumentNullException("dataService");

//            m_dataService = dataService;
//            User = m_dataService.User;
//    }
//}
