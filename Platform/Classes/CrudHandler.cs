
//using Boytrix.Logic.Business.Common;
//using Boytrix.UI.WPF.Libraries.Base.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.UI.WPF.Libraries.Platform.Crud
//{
//    public class CrudHandler<T>  where T : class
//    {
//        //private IUnitOfWork _unitOfWork;
//        private List<Boytrix.Logic.Business.Common.CrudedItem<T>> CrudedItemCollection = new List<CrudedItem<T>>();
//        private Boytrix.Logic.DataTransfer.DbUpdate.UnitOfWork.DbUpdater _service;
//        public CrudHandler(Boytrix.Logic.DataTransfer.DbUpdate.UnitOfWork.DbUpdater service)
//        {
//            _service = service;
//        }

     
       
//        private Dictionary<string, object> mOriginalValues = new Dictionary<string, object>();
//        private Dictionary<string, object> mTypes = new Dictionary<string, object>();

//        private void Initialize(T obj)
//        {
//            mOriginalValues.Clear();
//            mTypes.Clear();
//            PropertyInfo[] properties = obj.GetType().GetProperties();

//            // Save the current value of the properties to our dictionary.
//            foreach (PropertyInfo property in properties)
//            {
//                this.mOriginalValues.Add(property.Name, property.GetValue(obj));
//            }


//            // Save the current Type of the properties to our dictionary.
//            foreach (PropertyInfo property in properties)
//            {
//                this.mTypes.Add(property.Name, property.PropertyType);
//            }

//        }


//        private string HandleNewItems(T obj)
//        {
//            // if (!EditedItems.Any(x=>x.FormState==FormMode.ADDMODE)) { return null; }
//            PropertyInfo[] properties = obj.GetType().GetProperties();




//            var SqlStatements = new StringBuilder();
//            var sbField = new StringBuilder();
//            var sbWhere = new StringBuilder();
//            var fld = new AttributeHelper<DoNotInsertFieldAttribute>();
//            List<string> fldNames = fld.HasField(obj);

//            var dicDbFieldNames = fld.DbFieldName(obj);


//            foreach (PropertyInfo property in properties)
//            {
//                if (!fldNames.Contains(property.Name))
//                {
//                    var matches = dicDbFieldNames.Where(kvp => kvp.Key == property.Name).FirstOrDefault();
//                    string fieldName = matches.Key == null ? property.Name : matches.Value;

//                    sbField.Append("[" + fieldName + "]" + ",");

//                    if (Boytrix.Logic.Business.Common.ExtensionMethods.IsNumericDatatype(property.PropertyType.ToString()))
//                        sbWhere.Append(property.GetValue(obj) + ",");
//                    else
//                        sbWhere.Append("'" + property.GetValue(obj) + "',");
//                }
//            }

//            sbField.Remove(sbField.ToString().LastIndexOf(","), 1);
//            sbWhere.Remove(sbWhere.ToString().LastIndexOf(","), 1);

//            SqlStatements.Append(" INSERT INTO " + obj.GetType().Name + " (" + sbField.ToString() + ") VALUES ( " + sbWhere + ")" + ";");
//            //SqlStatements.Append(" GO ");

//            return SqlStatements.ToString();
//        }

//        private string HandleEditedItems(T obj)
//        {

//            // if (!EditedItems.Any(x => x.FormState == FormMode.EDITMODE)) { return null ; }


//            var SqlStatements = new StringBuilder();

//            PropertyInfo[] properties = obj.GetType().GetProperties();
//            var latestChanges = new Dictionary<string, object>();

//            // Save the current value of the properties to our dictionary.
//            foreach (PropertyInfo property in properties)
//            {
//                latestChanges.Add(property.Name, property.GetValue(obj));
//            }

//            // Get all properties
//            PropertyInfo[] tempProperties = obj.GetType().GetProperties().ToArray();

//            // Filter properties by only getting what has changed
//            properties = tempProperties.Where(p => !Equals(p.GetValue(obj, null), this.mOriginalValues[p.Name])).ToArray();


//            latestChanges.Clear();

//            string strAnd = " AND ";

//            var sbField = new StringBuilder();

//            //Get custom attributes that exclude a field or provides proper db name for a field
//            var fld = new AttributeHelper<DoNotInsertFieldAttribute>();
//            List<string> fldNames = fld.HasField(obj);
//            var dicDbFieldNames = fld.DbFieldName(obj);


//            foreach (PropertyInfo property in properties)
//            {
//                if (!fldNames.Contains(property.Name))
//                {
//                    latestChanges.Add(property.Name, property.GetValue(obj));
//                    // sql = "[" + property.Name.ToString() + "]=" + property.GetValue(obj) + "";
//                    //KeyValuePair<string, string> properFieldName = dicDbFieldNames.ContainsKey(property.Name);
//                    var matches = dicDbFieldNames.Where(kvp => kvp.Key == property.Name).FirstOrDefault();
//                    if (Boytrix.Logic.Business.Common.ExtensionMethods.IsNumericDatatype(property.PropertyType.ToString()))
//                        sbField.Append("[" + matches == null ? property.Name.ToString() : matches.Value + "]=" + property.GetValue(obj) + ",");
//                    else
//                        sbField.Append("[" + matches == null ? property.Name.ToString() : matches.Value + "]='" + property.GetValue(obj) + "',");
//                }
//            }

//            sbField.Remove(sbField.ToString().LastIndexOf(","), 1);


//            var sbWhere = new StringBuilder();

//            foreach (var entry in mOriginalValues)
//            {
//                if (!fldNames.Contains(entry.Key))
//                {
//                    var item = mTypes.FirstOrDefault(t => t.Key == entry.Key);
//                    if (Boytrix.Logic.Business.Common.ExtensionMethods.IsNumericDatatype(item.Value.ToString()))
//                        sbWhere.Append("[" + entry.Key + "] =" + entry.Value + " AND ");
//                    else
//                        sbWhere.Append("[" + entry.Key + "] ='" + entry.Value + "' AND ");
//                }
//                // strWhere = strWhere + "[" + entry.Key  + "] ='" + entry.Value + "' AND ";
//            }


//            sbWhere.Remove(sbWhere.ToString().LastIndexOf(strAnd), strAnd.Length);

//            //tempProperties = tempProperties.Where(p => !Equals(p.GetValue(obj, null), this.mOriginalValues[p.Name])).ToArray();
//            SqlStatements.Append(" UPDATE " + obj.GetType().Name + " SET " + sbField.ToString() + " WHERE " + sbWhere.ToString() + ";");
//            // SqlStatements.Append(" GO ");
//            return SqlStatements.ToString();
//        }

//        private string HandleDeletedItems(T obj)
//        {

//            Initialize(obj);//get original field values
//            var SqlStatements = new StringBuilder();


//            string strAnd = " AND ";

//            var fld = new AttributeHelper<DoNotInsertFieldAttribute>();
//            List<string> fldNames = fld.HasField(obj);
//            var dicDbFieldNames = fld.DbFieldName(obj);
//            var sbWhere = new StringBuilder();

//            foreach (var entry in mOriginalValues)
//            {
//                if (!fldNames.Contains(entry.Key))
//                {
//                    var matches = dicDbFieldNames.FirstOrDefault(kvp => kvp.Key == entry.Key);
//                    var item = mTypes.FirstOrDefault(t => t.Key == entry.Key);
//                    string fieldName = matches.Key == null ? entry.Key : matches.Value;

//                    if (Boytrix.Logic.Business.Common.ExtensionMethods.IsNumericDatatype(item.Value.ToString()))
//                        sbWhere.Append("[" + fieldName + "] =" + entry.Value + strAnd);
//                    else
//                        sbWhere.Append("[" + fieldName + "] ='" + entry.Value + "' AND ");
//                }
//            }

//            sbWhere.Remove(sbWhere.ToString().LastIndexOf(strAnd), strAnd.Length);
//            SqlStatements.Append(" DELETE FROM " + obj.GetType().Name + " WHERE " + sbWhere.ToString() + ";");
//            // SqlStatements.Append(" GO ");
//            return SqlStatements.ToString();
//        }


//        public void HandleSaveNoCommit(T obj, FormMode state)
//        {
//            var row = new CrudedItem<T>();
//            row.DataRow = obj;
//            row.FormState = state;

//            switch (state)
//            {
//                case FormMode.ADDMODE:
//                    row.SqlStatement = HandleNewItems(obj);
//                    break;
//                case FormMode.EDITMODE:
//                    row.SqlStatement = HandleEditedItems(obj);
//                    break;

//                case FormMode.DELETEMODE:
//                    row.SqlStatement = HandleDeletedItems(obj);
//                    break;

//                default:
//                    row.SqlStatement = HandleNewItems(obj);
//                    break;
//            }
//            CrudedItemCollection.Add(row);
//        }


//        internal void HandleUpdateDb(Action<string> UpdatedCompleted)
//        {
//            var sb = new StringBuilder();
//            CrudedItemCollection.ToList().ForEach(x => sb.Append(x.SqlStatement));
//            UpdateDb(sb.ToString(), (errMsg) =>
//            {

//                CrudedItemCollection.Clear();
//                UpdatedCompleted(errMsg);
//            });

//        }

//        public void UpdateDb(string sqlStatements, Action<string> completed)
//        {
//            _service.UpdateDb(sqlStatements,(msg)=>
//            {
//                completed(msg);
//            });
            
//        }

//        public void ClearCrudedItems()
//        {
//            CrudedItemCollection.Clear();
//        }
//        public ObservableCollection<T> EditedItems()
//        {
//            var obj = new ObservableCollection<T>();
//            CrudedItemCollection.ToList().ForEach(x => obj.Add(x.DataRow));
//            return obj;
//        }
//        public bool HasPendingCommits()
//        {
//            //? MsgBoxResult.OK : MsgBoxResult.Cancel;
//            return CrudedItemCollection==null?false:CrudedItemCollection.Any();
//        }

     
//    }
//}
