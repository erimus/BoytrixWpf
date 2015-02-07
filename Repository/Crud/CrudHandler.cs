

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.DataTransfer.Materializer;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public class CrudHandler<T>  where T : class
    {
        //private IUnitOfWork _unitOfWork;
        private List<CrudedItem<T>> CrudedItemCollection = new List<CrudedItem<T>>();
        private List<CrudedItem<T>> StoredProcedureCollection= new List<CrudedItem<T>>();

        public Dictionary<string, string> XmlFiles = new Dictionary<string, string>();


        private MaterializedObject<T> materializer;
        public CrudHandler(MaterializedObject <T> materializer)
        {
            this.materializer = materializer;
        }

     
       
        private Dictionary<string, object> mOriginalValues = new Dictionary<string, object>();
        private Dictionary<string, object> mTypes = new Dictionary<string, object>();

        private void Initialize(T obj)
        {
            mOriginalValues.Clear();
            mTypes.Clear();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            // Save the current value of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                mOriginalValues.Add(property.Name, property.GetValue(obj));
            }


            // Save the current Type of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                mTypes.Add(property.Name, property.PropertyType);
            }

        }


        private string HandleNewItems(T obj)
        {
            // if (!EditedItems.Any(x=>x.FormState==FormMode.ADDMODE)) { return null; }
            PropertyInfo[] properties = obj.GetType().GetProperties();




            var SqlStatements = new StringBuilder();
            var sbField = new StringBuilder();
            var sbWhere = new StringBuilder();
            var fld = new AttributeHelper<DoNotIncludeField>();
            List<string> fldNames = fld.HasField(obj);

            var dicDbFieldNames = fld.DbFieldName(obj);


            foreach (PropertyInfo property in properties)
            {
                if (!fldNames.Contains(property.Name))
                {
                    var matches = dicDbFieldNames.Where(kvp => kvp.Key == property.Name).FirstOrDefault();
                    string fieldName = matches.Key == null ? property.Name : matches.Value;

                    sbField.Append("[" + fieldName + "]" + ",");

                    if (property.PropertyType.ToString().IsNumericDatatype())
                    {
                        sbWhere.Append(property.GetValue(obj));
                        //because bool is bit in sql do the following
                        sbWhere = sbWhere.Replace("True", "1");
                        sbWhere = sbWhere.Replace("False", "0");
                    }
                    else
                    {
                        //sbWhere.Append("'" + property.GetValue(obj) + "',");
                        sbWhere.Append(DB.SQuote(property.GetValue(obj).ToString()));
                       
                    }
                    sbWhere.Append(",");
                }
            }

            sbField.Remove(sbField.ToString().LastIndexOf(","), 1);
            sbWhere.Remove(sbWhere.ToString().LastIndexOf(","), 1);



            var attributes = typeof(T).GetCustomAttributes<DbTableName>();

            string tableName = ReadClassAttribute.GetDisplayAttributeValue(attributes);
              tableName=  tableName==""?obj.GetType().Name :tableName;

              SqlStatements.Append(" INSERT INTO " + tableName + " (" + sbField + ") VALUES ( " + sbWhere + ")" + ";");
            //SqlStatements.Append(" GO ");

            return SqlStatements.ToString();
        }

        private string HandleEditedItems(T obj)
        {

            // if (!EditedItems.Any(x => x.FormState == FormMode.EDITMODE)) { return null ; }


            var SqlStatements = new StringBuilder();

            PropertyInfo[] properties = obj.GetType().GetProperties();
            var latestChanges = new Dictionary<string, object>();

            // Save the current value of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                latestChanges.Add(property.Name, property.GetValue(obj));
            }

            // Get all properties
            PropertyInfo[] tempProperties = obj.GetType().GetProperties().ToArray();

            // Filter properties by only getting what has changed
            properties = tempProperties.Where(p => !Equals(p.GetValue(obj, null), mOriginalValues[p.Name])).ToArray();


            latestChanges.Clear();

            string strAnd = " AND ";

            var sbField = new StringBuilder();

            //Get custom attributes that exclude a field or provides proper db name for a field
            var fld = new AttributeHelper<DoNotIncludeField>();
            List<string> fldNames = fld.HasField(obj);
            var dicDbFieldNames = fld.DbFieldName(obj);


            foreach (PropertyInfo property in properties)
            {
                if (!fldNames.Contains(property.Name))
                {
                    latestChanges.Add(property.Name, property.GetValue(obj));
                    // sql = "[" + property.Name.ToString() + "]=" + property.GetValue(obj) + "";
                    //KeyValuePair<string, string> properFieldName = dicDbFieldNames.ContainsKey(property.Name);
                    var matches = dicDbFieldNames.Where(kvp => kvp.Key == property.Name).FirstOrDefault();
                    if (property.PropertyType.ToString().IsNumericDatatype())
                        sbField.Append("[" + matches == null ? property.Name : matches.Value + "]=" + property.GetValue(obj) + ",");
                    else
                        sbField.Append("[" + matches == null ? property.Name : matches.Value + "]='" + property.GetValue(obj) + "',");
                }
            }

            sbField.Remove(sbField.ToString().LastIndexOf(","), 1);


            var sbWhere = new StringBuilder();

            foreach (var entry in mOriginalValues)
            {
                if (!fldNames.Contains(entry.Key))
                {
                    var item = mTypes.FirstOrDefault(t => t.Key == entry.Key);
                    if (item.Value.ToString().IsNumericDatatype())
                        sbWhere.Append("[" + entry.Key + "] =" + entry.Value + " AND ");
                    else
                        sbWhere.Append("[" + entry.Key + "] ='" + entry.Value + "' AND ");
                }
                // strWhere = strWhere + "[" + entry.Key  + "] ='" + entry.Value + "' AND ";
            }


            sbWhere.Remove(sbWhere.ToString().LastIndexOf(strAnd), strAnd.Length);


            var attributes = typeof(T).GetCustomAttributes<DbTableName>();

            string tableName = ReadClassAttribute.GetDisplayAttributeValue(attributes);
            tableName = tableName == "" ? obj.GetType().Name : tableName;


            //tempProperties = tempProperties.Where(p => !Equals(p.GetValue(obj, null), this.mOriginalValues[p.Name])).ToArray();
            SqlStatements.Append(" UPDATE " + tableName + " SET " + sbField + " WHERE " + sbWhere + ";");
            // SqlStatements.Append(" GO ");
            return SqlStatements.ToString();
        }

        private string HandleDeletedItems(T obj)
        {

            Initialize(obj);//get original field values
            var SqlStatements = new StringBuilder();


            string strAnd = " AND ";

            var fld = new AttributeHelper<DoNotIncludeField>();
            List<string> fldNames = fld.HasField(obj);
            var dicDbFieldNames = fld.DbFieldName(obj);
            var sbWhere = new StringBuilder();

            foreach (var entry in mOriginalValues)
            {
                if (!fldNames.Contains(entry.Key))
                {
                    var matches = dicDbFieldNames.FirstOrDefault(kvp => kvp.Key == entry.Key);
                    var item = mTypes.FirstOrDefault(t => t.Key == entry.Key);
                    string fieldName = matches.Key == null ? entry.Key : matches.Value;

                    if (item.Value.ToString().IsNumericDatatype())
                        sbWhere.Append("[" + fieldName + "] =" + entry.Value + strAnd);
                    else
                        sbWhere.Append("[" + fieldName + "] ='" + entry.Value + "' AND ");
                }
            }

            sbWhere.Remove(sbWhere.ToString().LastIndexOf(strAnd), strAnd.Length);


            var attributes = typeof(T).GetCustomAttributes<DbTableName>();

            string tableName = ReadClassAttribute.GetDisplayAttributeValue(attributes);
            tableName = tableName == "" ? obj.GetType().Name : tableName;


            SqlStatements.Append(" DELETE FROM " + tableName + " WHERE " + sbWhere + ";");
            // SqlStatements.Append(" GO ");
            return SqlStatements.ToString();
        }


        private string HandleFind(T obj, string strWhere)
        {
            var fld = new AttributeHelper<DoNotIncludeField>();
            List<string> fldNames = fld.HasField(obj);
            var dicDbFieldNames = fld.DbFieldName(obj);
            string strAnd = " OR ";
            var sbWhere = new StringBuilder();

           // var sql= HandleGet(obj);
            foreach (var item in mTypes)
            {
                //if (Boytrix.Logic.Business.Common.ExtensionMethods.IsNumericDatatype(item.Value.ToString()))
                //    sbWhere.Append("[" + item.Key + "] LIKE %" + strWhere + "% OR ");
                //else
                    sbWhere.Append("[" + item.Key + "]  LIKE'%" + strWhere + "%' OR ");
            }


            sbWhere.Remove(sbWhere.ToString().LastIndexOf(strAnd), strAnd.Length);


            return  " WHERE " + sbWhere;
        }

        private string HandleGet(T obj)
        {

          

            var fld = new AttributeHelper<DoNotIncludeField>();
            List<string> fldNames = fld.HasField(obj);

            mTypes.Clear();

            var dicDbFieldNames = fld.DbFieldName(obj);
            var sbField = new StringBuilder();

            //List<string> cols = fld.HasField(obj);

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Add type should we need it for find
                mTypes.Add(property.Name, property.PropertyType);

            }
            mTypes.ToList().ForEach(pair => { if (fldNames.Contains(pair.Key)) mTypes.Remove(pair.Key); });

            mTypes.ToList().ForEach(pair => { sbField.Append(pair.Key); sbField.Append(","); });
            
            
                

            var attributes = typeof(T).GetCustomAttributes<DbTableName>();

            string tableName = ReadClassAttribute.GetDisplayAttributeValue(attributes);
            tableName = tableName == "" ? obj.GetType().Name : tableName;

            sbField.Remove(sbField.ToString().LastIndexOf(","), 1);

            return " SELECT "+sbField + " FROM " + tableName + "";
            
        }
        public void HandleSaveNoCommitSQL(T obj, FormMode state)
        {
            var row = new CrudedItem<T>();
            row.DataRow = obj;
            row.FormState = state;

            switch (state)
            {
                case FormMode.ADDMODE:
                    row.SqlStatement = HandleNewItems(obj);
                    break;
                case FormMode.EDITMODE:
                    row.SqlStatement = HandleEditedItems(obj);
                    break;

                case FormMode.DELETEMODE:
                    row.SqlStatement = HandleDeletedItems(obj);
                    break;

                default:
                    row.SqlStatement = HandleNewItems(obj);
                    break;
            }
            CrudedItemCollection.Add(row);
        }

        public void HandleDeleteNotCommitted(T row, FormMode state)
        {

            CrudedItemCollection.RemoveAll(x => x.DataRow == row && x.FormState == state);

        }

        public void HandleSaveNoCommitSP(T obj, FormMode state,string execStatement)
        {
            var row = new CrudedItem<T>();
            row.DataRow = obj;
            row.FormState = state;
            row.SqlStatement = execStatement+";";
            CrudedItemCollection.Add(row);
        }
        
   
        internal void HandleUpdateDb(Action<string> UpdatedCompleted)
        {
            var sb = new StringBuilder();
            CrudedItemCollection.ToList().ForEach(x => sb.Append(x.SqlStatement));
            UpdateDb(sb.ToString(), errMsg =>
            {

                CrudedItemCollection.Clear();
                UpdatedCompleted(errMsg);
            });

        }

        public void UpdateDb(string sqlStatements, Action<string> completed)
        {
            materializer.UpdateDb(sqlStatements, msg =>
            {
                completed(msg);
            });
            
        }

        public void ClearCrudedItems()
        {
            CrudedItemCollection.Clear();
        }
        public ObservableCollection<T> EditedItems()
        {
            var obj = new ObservableCollection<T>();
            CrudedItemCollection.ToList().ForEach(x => obj.Add(x.DataRow));
            return obj;
        }
        public bool HasPendingCommits()
        {
            //? MsgBoxResult.OK : MsgBoxResult.Cancel;
            return CrudedItemCollection==null?false:CrudedItemCollection.Any();
        }


        public void GetAll(T obj, string className, Action<IEnumerable<T>> UpdatedCompleted)
        {

            string sql = HandleGet(obj);

            Debug.WriteLine("materializer called");

            materializer.GetAll(className, sql, x =>
            {   
                UpdatedCompleted(x);
            });
        }
        public void Find(T obj, string className, string searchValue, Action<IEnumerable<T>> UpdatedCompleted)
        {
            string select = HandleGet(obj);
            string where = HandleFind(obj, searchValue);
            string sql = select + " " + where;

            Debug.WriteLine("materializer called");

            materializer.Find(className, sql, x =>
            {

                UpdatedCompleted(x);
            });
        }

        public string GetSqlSearch(string sprocName, string elementName, Dictionary<string, object> paramList)
        {
            StringBuilder command = new StringBuilder();
            command.Append(sprocName);

            string sql = command.ToString().TrimEnd(',');

            if (paramList != null)
                foreach (object value in paramList.Values)
                {
                    command.Append(value);
                    command.Append(",");
                }

            sql = command.ToString().TrimEnd(',');
            return sql;
        }

        public void HandleGetWithSP(string sprocName, string elementName, Action<bool, string> completed)
        {
            if (!XmlFiles.ContainsKey(elementName))
            {
                XmlFiles.Add(elementName, sprocName);
                materializer.GetWithSp(sprocName, elementName, (x, xml) =>
                {
                    completed(x, sprocName);
                });
            }
            else
            {
                string oldSearch = XmlFiles[elementName];
                if (oldSearch != sprocName)
                {
                    XmlFiles.Remove(elementName);
                    XmlFiles.Add(elementName, sprocName);
                    materializer.GetWithSp(sprocName, elementName, (x, xml) =>
                    {
                        completed(x, sprocName);
                    });

                }
                else
                {
                    materializer.GetDataFromXml(sprocName, elementName, x =>
                    {
                        completed(x, sprocName);

                    });
                }
            }

        }

        public ObservableCollection<T> GetRelatedItems()
        {
            var obj = new ObservableCollection<T>();
            CrudedItemCollection.ToList().ForEach(x => obj.Add(x.DataRow));
            return obj;
        }
    }
}
