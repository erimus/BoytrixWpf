using System;
using System.Collections.Generic;
using System.Reflection;

namespace Boytrix.Logic.Business.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class DbTableName : Attribute
    {
        private string _tableName;
        public DbTableName(string tableName)
        {
            _tableName = tableName;
        }
        public string GetName()
        {
            return _tableName;
        }

    }



    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DoNotIncludeField : Attribute
    {
    }


    public class AttributeHelper<T> where T : Attribute
    {

        public List<string> HasField(object obj)
        {
            //Querying Class-Field (only public) Attributes
            PropertyInfo[] properties = obj.GetType().GetProperties();
            var lst = new List<string>();
            foreach (PropertyInfo field in properties)
            {
                foreach (Attribute attr in field.GetCustomAttributes(true))
                {
                    var helpAttr = attr as T;
                    if (null != helpAttr)
                    {
                        lst.Add(field.Name);

                    }
                }
            }
            return lst;
        }

        public Dictionary<string, string> DbFieldName(object obj)
        {
            var dic = new Dictionary<string, string>();
            DbFieldAttribute helpAttr;

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo field in properties)
            {
                foreach (Attribute attr in field.GetCustomAttributes(true))
                {
                    helpAttr = attr as DbFieldAttribute;
                    if (null != helpAttr)
                    {
                        dic.Add(field.Name, helpAttr.FieldName(field));

                    }
                }
            }
            return dic;

            //dic.Add( obj.GetType()
            //   .GetProperties()
            //   .Where(x => x.GetCustomAttributes().OfType<DbFieldAttribute>().Any())
            //   .ToList()
            //   .ForEach(x => (x.GetCustomAttributes().OfType<DbFieldAttribute>().First() as DbFieldAttribute).FieldName(x));


        }


    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DbFieldAttribute : Attribute
    {
        private string fieldName = "";

        public DbFieldAttribute() { }

        public DbFieldAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public string FieldName(PropertyInfo pi)
        {
            if (fieldName != "") return fieldName;
            return pi.Name;
        }

        public string FieldName(FieldInfo fi)
        {
            if (fieldName != "") return fieldName;
            return fi.Name;
        }
    }

    public enum Join{
        INNER,
        LEFT,
        RIGHT
    }

    //[AttributeUsage(AttributeTargets.Class)]
    //public class FieldRelationShip : Attribute
    //{
    //    // Private fields. 
    //    private string primaryKey;
    //    private string foreignKey;
    //    private string primaryTable;
    //    private Join join;
    //    private string  foreignKeyTable;
    //    // This constructor defines two required parameters: name and level. 

    //    public FieldRelationShip(string primaryTable, string primaryKey, Join join, string foreignKeyTable, string foreignKey)
    //    {
    //        this.primaryKey = primaryKey;
    //        this.foreignKey = foreignKey;
    //        this.primaryTable = primaryTable;
    //        this.join = join;
    //        this.foreignKeyTable = foreignKeyTable;
    //    }

    //    // Define Name property. 
    //    // This is a read-only attribute. 

    //    public virtual string PrimaryKey
    //    {
    //        get { return primaryKey; }
    //    }
    //    public virtual string ForeignKey
    //    {
    //        get { return foreignKey; }
    //    }
    //    public virtual string PrimaryTable
    //    {
    //        get { return primaryTable; }
    //    }
    //    public virtual Join Join
    //    {
    //        get { return join; }
    //    }
    //    public virtual string ForeignKeyTable
    //    {
    //        get { return foreignKeyTable; }
    //    }
    //}


    //public class DbRelatiionship
    //{

    //    public Dictionary<string, string> DbRelation(object obj)
    //    {
    //        var dic = new Dictionary<string, string>();
    //        FieldRelationShip helpAttr;
    //        string str;
    //        PropertyInfo[] properties = obj.GetType().GetProperties();

    //        foreach (PropertyInfo field in properties)
    //        {
    //            foreach (Attribute attr in field.GetCustomAttributes(true))
    //            {
    //                helpAttr = attr as FieldRelationShip;
    //                if (null != helpAttr)
    //                {
    //                   // dic.Add(helpAttr.PrimaryKey, helpAttr.ForeignKey);
    //                    str=helpAttr.Join.ToString()  + "  " + helpAttr.ForeignKeyTable + " AS" + helpAttr.ForeignKeyTable+ " ON " + helpAttr.PrimaryTable+"."+helpAttr.PrimaryKey+" = "+helpAttr.ForeignKey;
    //                }
    //            }
    //        }
    //        return dic;

    //        //dic.Add( obj.GetType()
    //        //   .GetProperties()
    //        //   .Where(x => x.GetCustomAttributes().OfType<DbFieldAttribute>().Any())
    //        //   .ToList()
    //        //   .ForEach(x => (x.GetCustomAttributes().OfType<DbFieldAttribute>().First() as DbFieldAttribute).FieldName(x));


    //    }
  //  }
}