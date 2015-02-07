namespace Boytrix.Logic.DataTransfer.Repository
{
    public interface ICrudHandler<T>
    {
        string HandleDeletedItems(T obj);
        string HandleEditedItems(T obj);
        string HandleNewItems(T obj);
    }
}
