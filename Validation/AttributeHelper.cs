//using System;
//using System.Reflection;
//using System.Linq;
//using System.Collections.Generic;
//namespace Boytrix.Logic.Model.Validation
//{
//    [AttributeUsage(AttributeTargets.Property)]
//    public class DoNotInsertFieldAttribute : System.Attribute
//    {
//    }


//    public class AttributeHelper<T> where T : System.Attribute
//    {
//        public List<string> HasField(object obj)
//        {
//            //Querying Class-Field (only public) Attributes
//            PropertyInfo[] properties = obj.GetType().GetProperties();
//            var lst = new List<string>();
//            foreach (PropertyInfo field in properties)
//            {
//                foreach (Attribute attr in field.GetCustomAttributes(true))
//                {
//                    var helpAttr = attr as T;
//                    if (null != helpAttr)
//                    {
//                        lst.Add(field.Name);

//                    }
//                }
//            }
//            return lst;
//        }

//        public Dictionary<string, string> DbFieldName(object obj)
//        {
//            var dic = new Dictionary<string, string>();
//            DbFieldAttribute helpAttr;

//            PropertyInfo[] properties = obj.GetType().GetProperties();

//            foreach (PropertyInfo field in properties)
//            {
//                foreach (Attribute attr in field.GetCustomAttributes(true))
//                {
//                    helpAttr = attr as DbFieldAttribute;
//                    if (null != helpAttr)
//                    {
//                        dic.Add(field.Name, helpAttr.FieldName(field));

//                    }
//                }
//            }
//            return dic;

//            //dic.Add( obj.GetType()
//            //   .GetProperties()
//            //   .Where(x => x.GetCustomAttributes().OfType<DbFieldAttribute>().Any())
//            //   .ToList()
//            //   .ForEach(x => (x.GetCustomAttributes().OfType<DbFieldAttribute>().First() as DbFieldAttribute).FieldName(x));


//        }
//    }

//    [AttributeUsage(AttributeTargets.Property)]
//    public class DbFieldAttribute : Attribute
//    {
//        private string fieldName = "";

//        public DbFieldAttribute() { }

//        public DbFieldAttribute(string fieldName)
//        {
//            this.fieldName = fieldName;
//        }

//        public string FieldName(PropertyInfo pi)
//        {
//            if (this.fieldName != "") return this.fieldName;
//            else return pi.Name;
//        }

//        public string FieldName(FieldInfo fi)
//        {
//            if (this.fieldName != "") return this.fieldName;
//            else return fi.Name;
//        }
//    }



//}