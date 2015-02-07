using System;
namespace Boytrix.Logic.Business.Common.Crud
{
    public interface ICrudHandler<T>
    {
        string HandleDeletedItems(T obj);
        string HandleEditedItems(T obj);
        string HandleNewItems(T obj);
    }
}
