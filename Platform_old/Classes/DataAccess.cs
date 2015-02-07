using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Classes
{
    class DataAccess
    {
        public void ForgotPassUpdatePasswordAsync(int userId, string newPassword, Action<object, AsyncCompletedEventArgs> completedAction)
        { }

         public void UpdateUserPasswordAsync(int userId, string oldPassword, string newPassword, Action<object, AsyncCompletedEventArgs> completedAction)
        { }

         public void InsertRegistrationDetailsAsync(
            string userDetails, string message, Action<object, AsyncCompletedEventArgs> completedAction)
         { }
    }
}
