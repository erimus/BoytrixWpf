using System;
using AspDotNetStorefrontEncrypt;

namespace Boytrix.UI.WPF.BoytrixModules.Login.Classes
{
    public class Password
    {
        private String m_ClearPassword = String.Empty;
        private int m_Salt;
        private String m_SaltedPassword = String.Empty;

        public static readonly int ro_RandomPasswordLength = 8;
        public static readonly int ro_RandomStrongPasswordLength = 8;

        public Password(String ClearPassword, int Salt)
        {
            m_ClearPassword = ClearPassword;
            m_Salt = Salt;
            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
        }


        public Password(String ClearPassword)
        {
            m_ClearPassword = ClearPassword;
            m_Salt = Encrypt.CreateRandomSalt();
            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
        }


        public Password()
        {
            m_ClearPassword = Encrypt.CreateRandomStrongPassword(8);
            m_Salt = Encrypt.CreateRandomSalt();
            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
        }


        public String ClearPassword
        {
            get { return m_ClearPassword; }
        }

        public String SaltedPassword
        {
            get { return m_SaltedPassword; }
        }

        public int Salt
        {
            get { return m_Salt; }
        }
    }

    public class RandomStrongPassword : Password
    {
        public RandomStrongPassword()
            : base(Encrypt.CreateRandomStrongPassword(ro_RandomStrongPasswordLength), Encrypt.CreateRandomSalt())
        {
        }
    }
}
