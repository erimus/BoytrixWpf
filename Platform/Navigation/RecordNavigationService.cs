using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public class RecordNavigationService<T> : ObservableCollection<T> where T : class
    {
        public RecordNavigationService(List<T> list)
            : base(list)
        {
        }

        public RecordNavigationService(IEnumerable<T> collection)
            : base(collection)
        {
        }

        private ICollectionView GetDefaultView()
        {
            return CollectionViewSource.GetDefaultView(this);
        }

        public int CurrentPosition
        {
            get
            {
                return GetDefaultView().CurrentPosition;
            }
        }

        public void MoveFirst()
        {
            GetDefaultView().MoveCurrentToFirst();
        }

        public void MovePrevious()
        {
            if (!GetDefaultView().IsCurrentBeforeFirst)
            {
                GetDefaultView().MoveCurrentToPrevious();
            }
        }

        public void MoveNext()
        {
            if (!GetDefaultView().IsCurrentAfterLast)
            {
                GetDefaultView().MoveCurrentToNext();
            }
        }

        public void MoveLast()
        {
            GetDefaultView().MoveCurrentToLast();
        }

        public T CurrentItem()
        {
            return GetDefaultView().CurrentItem as T;
        }

   
    }
}
