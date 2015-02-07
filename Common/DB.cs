using System;
using System.Text;

namespace Boytrix.Logic.Business.Common
{
    public class DB
    {
        public static String SQuote(String s)
        {
            int len = s.Length + 25;
            StringBuilder tmpS = new StringBuilder(len); // hopefully only one alloc
            tmpS.Append("N'");
            tmpS.Append(s.Replace("'", "''"));
            tmpS.Append("'");
            return tmpS.ToString();
        }

        public static String SQuoteNotUnicode(String s)
        {
            int len = s.Length + 25;
            StringBuilder tmpS = new StringBuilder(len); // hopefully only one alloc
            tmpS.Append("'");
            tmpS.Append(s.Replace("'", "''"));
            tmpS.Append("'");
            return tmpS.ToString();
        }

        public static String DateQuote(String s)
        {
            int len = s.Length + 25;
            StringBuilder tmpS = new StringBuilder(len); // hopefully only one alloc
            tmpS.Append("'");
            tmpS.Append(s.Replace("'", "''"));
            tmpS.Append("'");
            return tmpS.ToString();
        }

    }
}
