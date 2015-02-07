

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Boytrix.Logic.Business.Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.DataTransfer.Repository
{

    public abstract class RepositoryBase<T> where T : class
    {
        
        protected CrudHandler<T> _crudHandler;
        protected Dictionary<string, string> SavedSearches = new Dictionary<string, string>();
        public RepositoryBase(CrudHandler<T> crudHandler)
        {
            _crudHandler = crudHandler;

        }

        public void  DeleteUncomittedItems(T obj,FormMode state)
        {
            _crudHandler.HandleDeleteNotCommitted(obj,state);
        }
        public void SaveNoCommit(FormMode state, T selectedRow)
        {
            _crudHandler.HandleSaveNoCommitSQL(selectedRow, state);

        }

        public void HandleSaveNoCommitSP(FormMode state, T selectedRow, string execStatement)
        {
            _crudHandler.HandleSaveNoCommitSP(selectedRow, state, execStatement);
        }



        public void UpdateDb(Action<string> UpdatedCompleted)
        {
            _crudHandler.HandleUpdateDb(x =>
            {

                UpdatedCompleted(x);
            });

        }


        public void ClearCrudedItems()
        {
            _crudHandler.ClearCrudedItems();
            if (DataStore != null)
                DataStore.Clear();
        }
        public ObservableCollection<T> ReviewEditedItems()
        {
            return _crudHandler.EditedItems();
        }
        public bool HasPendingCommits()
        {
            return _crudHandler.HasPendingCommits();
        }

        public ObservableCollection<T> DataStore { get; set; }

        public string TaskResult { get; set; }
        public IEnumerable<T> ViewModelData { get; set; }
        public abstract void GetModelData(Action<object, EventHandler> completedAction);
        //protected abstract Task<IEnumerable<T>> GetMaterializedObject();

        //protected abstract Task<string> GetXmlFromServiceAsync();


        protected void Dispose()
        {
            Dispose();
        }


        protected void SearchDbWithSp( string sprocName, string elementName, Dictionary<string, object> paramList, Action<bool> completed)
        {

            string newsearch = _crudHandler.GetSqlSearch(sprocName, elementName, paramList);
            if (!SavedSearches.ContainsKey(elementName))
                SavedSearches.Add(elementName, newsearch);
            else
            {
                string Search = SavedSearches[elementName];
                if (Search != newsearch)
                {
                    SavedSearches.Remove(elementName);
                    SavedSearches.Add(elementName, newsearch);
                }
            }
            _crudHandler.HandleGetWithSP(newsearch, elementName, (o, query) =>
            {
                if (!SavedSearches.ContainsKey(elementName))
                    SavedSearches.Add(elementName, query);
                completed(o);
            });
                
        }

        //public void GetWtihSp( string param, Action UpdatedCompleted)
        //{

        //    var materializer = new MaterializedObject<T>();

        //    Debug.WriteLine("materializer instantiated");

        //    materializer.GetAll(className, sql, (x) =>
        //    {

        //        ViewModelData = x;
        //        UpdatedCompleted();
        //    });
        //}


        public void GetAll(T obj, string className, Action UpdatedCompleted)
        {


            _crudHandler.GetAll(obj,className, x =>
            {
                ViewModelData = x;
                UpdatedCompleted();
            });
        }

     


        public void Find(T obj, string searchValue,string className,Action UpdatedCompleted)
        {

            _crudHandler.Find(obj, className, searchValue, x =>
            {

                ViewModelData = x;
                UpdatedCompleted();
            });
        }


     

 //       public void GetWithSp(string sprocName, Dictionary<string, object> paramList, Action UpdatedCompleted)
 //       {


 ////"EXECUTE [dbo].[usp_Unitofwork_getsp] @id = {0}, @Login = {1}"
 //            //DB.ExecuteLongTimeSQL(string.Format("Exec Shipment_UpdateShipmentDetails {0},{1}", DB.SQuote(ord.ShipmentID), DB.SQuote(ord.GetXML())), 0);

 //           var materializer = new MaterializedObject<T>();
 //           materializer.GetWithSp(sql);
 //           Debug.WriteLine("materializer instantiated");

 //           //materializer.GetWithSp(sprocName, paramList, (x) =>
 //           //{

 //           //    ViewModelData = x;
 //           //    UpdatedCompleted();
 //           //});
 //       }


        internal string GetXmlFile(string searchKey)
        {
            if (SavedSearches.ContainsKey(searchKey))
            {
                var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                var file = SavedSearches[searchKey];

                string myDataService = container.Resolve<string>(searchKey);
                return myDataService;


                
            }


            return null;
        }
    }

}
