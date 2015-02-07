using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.DataAccess.Repository
{
    public interface IUnitOfWork<T> where T : class
    {
         void Insert(T entity);
         void Delete(T entity);

         IList<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
         IList<T> GetAll();

         T GetById(int id);
    }
}
