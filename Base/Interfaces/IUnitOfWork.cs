using System;

namespace Boytrix.UI.WPF.Libraries.Base.Interfaces
{
    public interface IUnitOfWork
    {
        void UpdateDb(string sqlStatements, Action<int> completed);
    }
}
