using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.DataAccess.Repository
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        IList<T> SearchFor(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        T GetById(int id);
        T GetById(string id);
    }
}
