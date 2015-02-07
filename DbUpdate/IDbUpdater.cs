using System;
namespace Boytrix.Logic.DataAccess.DbUpdate
{
    interface IDbUpdater
    {
        void UpdateDb(string sqlStatements, Action<string> completed);
    }
}
