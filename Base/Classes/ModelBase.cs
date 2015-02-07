using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Boytrix.UI.WPF.Libraries.Base.Classes
{
    public abstract class ModelBase<T>:ObservableCollection<T>
    {
        IList<T> AddedObjects { get; set; }
        IList<T> EditedObjects { get; set; }
        IList<T> DeletedObjects { get; set; }

      
    }
}
