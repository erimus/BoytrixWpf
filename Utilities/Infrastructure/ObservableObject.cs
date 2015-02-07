
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Boytrix.UI.Common.Utilities.Infrastructure
{

    /// <summary>
    /// Observable Object Class
    /// </summary>
    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// The PropertyChangedEventHandler
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Warns the developer if this Object does not have a public property with
        /// the specified name. This method does not exist in a Release build.
        /// </summary>
        /// <param name="propertyName">
        /// The property Name.
        /// </param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // verify that the property name matches a real,  
            // public, instance property on this Object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                Debug.Fail("Invalid property name: " + propertyName);
            }
        }

        /// <summary>
        /// The OnPropertyChanged
        /// </summary>
        /// <param name="e">
        ///  e event arguments
        /// </param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// raise property changed event
        /// </summary>
        /// <param name="propertyExpresssion">
        /// The property expresssion.
        /// </param>
        /// <typeparam name="T">
        /// parameter of type t
        /// </typeparam>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// raise property changed overload
        /// </summary>
        /// <param name="propertyName">
        /// The property name.  
        /// </param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
