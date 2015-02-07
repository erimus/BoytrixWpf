using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Boytrix.UI.WPF.Libraries.Base
{
    public class DataService<T> : ObservableCollection<T> where T : class 
    {

        public DataService() : base()
        {
            CollectionChanged += new NotifyCollectionChangedEventHandler(DataService_CollectionChanged);
        }

        private void DataService_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    var changed = item as INotifyPropertyChanged;
                    if (changed != null)
                        changed.PropertyChanged +=
                            new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    var changed = item as INotifyPropertyChanged;
                    if (changed != null)
                        changed.PropertyChanged -=
                            new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs a =
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(a);
        }
    }
}