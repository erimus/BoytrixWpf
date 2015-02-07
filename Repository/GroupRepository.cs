using System;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;

namespace Boytrix.Logic.DataAccess.Repository
{
    public class GroupRepository: RepositoryBase<UserGroup>
    {
        public GroupRepository(CrudHandler<UserGroup> crudHandler)
            : base(crudHandler)
        {
        }
        public override void GetModelData(Action<object, EventHandler> completedAction)
        {
            throw new NotImplementedException();
        }

      
    }
}
