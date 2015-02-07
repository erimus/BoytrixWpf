using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel.Tasks
{
    public class EditedItem
    {
        string OldValue { get; set; }
        string NewValue { get; set; }
        string FieldName { get; set; }
        string FieldType { get; set; }
    }

    public class EditedItems
    {
        IList<EditedItem> EditedList { get; set; }
    }


    //public class PropertyTypeAndValues
    //{
    //    void ReportValue(String propName, Object propValue);
    //    public void ReadList<T>(T list) where T : System.Collections.IList
    //    {
    //        foreach (Object item in list)
    //        {
    //            var props = item.GetType().GetProperties();
    //            foreach (var prop in props)
    //            {
    //                ReportValue(prop.Name, prop.GetValue(item, null));
    //            }
    //        }
    //    }


     
    //}


  
}
