using System;
using System.Collections.Generic;

namespace Boytrix.Logic.Business.Common
{

    public class ReadClassAttribute
    {
        public static string GetDisplayAttributeValue(IEnumerable<DbTableName> attrs)
        {
            foreach (Attribute attr in attrs)
            {
                var helpAttr = attr as DbTableName;
                if (null != helpAttr)
                {
                    return helpAttr.GetName();

                }
            }
            return "";
        }
    }

    //public class ReadRelationshipAttribute
    //{
    //    public static string GetDisplayAttributeValue(IEnumerable<FieldRelationShip> attrs)
    //    {
    //        string str;
    //        foreach (Attribute attr in attrs)
    //        {
    //            var helpAttr = attr as FieldRelationShip;
    //            if (null != helpAttr)
    //            {
    //                str = helpAttr.Join.ToString() + " JOIN " + helpAttr.ForeignKeyTable + " ON " + helpAttr.PrimaryTable + "." + helpAttr.PrimaryKey + " = " + helpAttr.ForeignKeyTable + "." + helpAttr.ForeignKey;

    //                return str;
    //            }
    //        }
    //        return "";
    //    }
    //}
}