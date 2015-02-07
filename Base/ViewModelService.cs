using System.Collections.Generic;
using Boytrix.Logic.DataTransfer.Repository;

namespace Boytrix.UI.WPF.Libraries.Base
{
    public class VmService<T> where T : class
    {
        public RepositoryBase<T> Repository { get; set; }
        public IEnumerable<T> CurrentRow { get; set; }
        public T CurrentItem { get; set; }
    }
}
