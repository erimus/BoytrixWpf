using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public class ViewNavigationService<T> : ObservableCollection<T> where T : class
    {
         public ViewNavigationService(List<T> list)
            : base(list)
        {
        }

        public ViewNavigationService(IEnumerable<T> collection)
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
