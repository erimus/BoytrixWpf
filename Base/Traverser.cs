using System.Collections.Generic;
using System.Linq;

namespace Boytrix.UI.WPF.Libraries.Base
{
    public static class Traverser
    {
        public static T NextIf<T>(this IEnumerable<T> source, T current)
        {
            var list = source.ToList();
            return list.Skip(list.IndexOf(current) + 1).Take(1).FirstOrDefault();
        }
        public static T PreviousIf<T>(this IEnumerable<T> source, T current)
        {
            var list = source.ToList();
            return list.Skip(list.IndexOf(current) - 1).Take(1).FirstOrDefault();
        }
    }
}
