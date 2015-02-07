//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Practices.Prism.Mvvm;
//using Boytrix.UI.WPF.BoytrixModules.Login.DataServices;
//using Microsoft.Practices.Prism.PubSubEvents;
//using Boytrix.UI.Common.Utilities.Infrastructure;

//namespace Boytrix.UI.WPF.BoytrixModules.Login.ViewModels
//{
//    public class UserViewModel : BindableBase
//    {
        
//        private IUserDataService m_dataService;
//        private readonly IEventAggregator eventAggregator;

//        public UserViewModel(IUserDataService dataService, IEventAggregator eventAggregator)
//        {

//            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");
//            this.eventAggregator = eventAggregator;

//            if (dataService == null) throw new ArgumentNullException("dataService");

//            m_dataService = dataService;
//            User = m_dataService.User;
//        }



//        //public User User { get; set; }
//    }
//}
