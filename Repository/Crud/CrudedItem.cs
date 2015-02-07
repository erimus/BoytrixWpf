using Boytrix.Logic.Business.Common;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public  class  CrudedItem<T> where T:class
    {
        public  string SqlStatement { get; set; }
        public  T DataRow { get; set; }
        public  FormMode FormState { get; set; }
    }
}
