using System;

namespace Boytrix.UI.WPF.Libraries.Base.Classes
{
    public   class InstanceFactory
    {
        public T GetInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Type.GetType(type));
        }

     
    }
}
