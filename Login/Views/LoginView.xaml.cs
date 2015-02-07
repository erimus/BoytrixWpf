
using System.Windows;
using System.Windows.Controls;

namespace Boytrix.UI.WPF.BoytrixModules.Login.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Write code here to authenticate user

            //string strUser = txtUserName.Text.Trim();
            //string strPwd = txtPassword.Password.ToString();
            //if (strUser.Equals(string.Empty))
            //{
            //   System.Windows.Forms.MessageBox.Show("Please enter the user id", "Stop", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            //   txtUserName.Focus();
            //    System.Windows.Forms.SendKeys.Send("{Home}+{End}");
            //    return;
            //}
            //txtMessage.Text = "Connecting....";
            //System.Windows.Forms.Application.DoEvents();

            //User user = new User();
            //user.Login = strUser;
            //if (user.CheckLogin(strPwd))
            //{
            //    if (user.IsActive)
            //    {
            //        IsLoginOK = true;
            //        Security.LogUserSession(user);
            //        Cache.CurrentUser = user;
            //        Security.CurrentUser = user;
            //        this.Visible = false;
            //        mdiFRM.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("User is deactivated, please contact your system administrator.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtUserId.Focus();
            //        SendKeys.Send("{Home}+{End}");
            //        return;
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Incorrect user id or password.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtUserId.Focus();
            //    SendKeys.Send("{Home}+{End}");
            //    return;
            //}
            //// If authenticated, then set DialogResult=true
            //DialogResult = true;
        }
    }
}
