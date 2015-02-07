
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.DataTransfer.Materializer
{
    public class MaterializedObject<T>
    {
        private DataGetter dataGetter;
        private Dictionary<string, string> XmlDataStore;
       
        public MaterializedObject(DataGetter dataGetter)
        {
            this.dataGetter = dataGetter;
            XmlDataStore = new Dictionary<string, string>();
        }

        public async void GetAll(string className,string sql, Action<IEnumerable<T>> completed)
        {

            Debug.WriteLine("DataGetter instantiated");

            string task = await dataGetter.GetAll(className, sql);
            if (task != "")
           
            {
 
                IEnumerable<T> newList = BoytrixSerializer.DeserializeParams<T>(task);
                var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                container.RegisterInstance(className, newList, new ContainerControlledLifetimeManager());
               completed(null);
            }
        }


        public async void Find(string className, string sql, Action<IEnumerable<T>> completed)
        {
           

            Debug.WriteLine("DataGetter instantiated");

            string task = await dataGetter.Find(className, sql);

          

            if (task != "")
            {
                IEnumerable<T> newList = BoytrixSerializer.DeserializeParams<T>(task);

                completed(newList);
            }
            else
                completed(null);
        }

        public async void GetWithSp(string sql, string className, Action<bool,string> completed)
        {

            Debug.WriteLine("XmlDataStore instantiated");
            string taskXml = await dataGetter.GetWtihSp(sql);

            //if (!XmlDataStore.ContainsKey(className))
            //{
            //    XmlDataStore.Add(className, taskXml);

            //}
            //else
            //{

            //    XmlDataStore.Remove(className);
            //    XmlDataStore.Add(className, taskXml);

            //}
        

            
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            container.RegisterInstance(className, taskXml, new ContainerControlledLifetimeManager());
            if (taskXml != "")
            {
                IEnumerable<T> newList = BoytrixSerializer.DeserializeParams<T>(className,taskXml);
                if (newList != null)
                {
                    var reg = container.Registrations.FirstOrDefault(r => r.Name == className && r.RegisteredType == typeof(IEnumerable<T>));

                    if (reg != null)
                    {
                        reg.LifetimeManager.RemoveValue();
                    }

                    container.RegisterInstance(className, newList, new ContainerControlledLifetimeManager());
                }
            }
           
            completed(true, taskXml);
        }

        public async void UpdateDb(string sqlStatements, Action<string> completed)
        {
            string task = await dataGetter.UpdateDb(sqlStatements, msg =>
            {
                completed(msg);
            });

        }

        public void GetDataFromXml(string sql,string className, Action<bool> completed)
        {

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var xml = container.Resolve<string>(className);

            IEnumerable<T> newList = BoytrixSerializer.DeserializeParams<T>(className,xml);
                if (newList != null)
                {
                    var reg = container.Registrations.FirstOrDefault(r => r.Name == sql && r.RegisteredType == typeof(IEnumerable<T>));

                    if (reg != null)
                    {
                        reg.LifetimeManager.RemoveValue();
                    }

                    container.RegisterInstance(className, newList, new ContainerControlledLifetimeManager());
                }


            completed(true);


        }
    }
}
