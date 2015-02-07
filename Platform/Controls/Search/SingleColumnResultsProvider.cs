using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls.Search
{
    public class SingleColumnResultsProvider : IIntelliboxResultsProvider
    {

        private List<string> _results;
        private int _numEach = 10;

        private void ConstructDataSource()
        {
            if (_results == null)
            {

                var temp = Enumerable.Range(0, 26 * _numEach).Select(i =>
                {
                    var count = i % _numEach + 1;
                    var charNum = (i / _numEach) % 26;
                    char ch = Convert.ToChar(charNum + Convert.ToInt32('a'));
                    return "".PadRight(count, ch);
                });

                _results = Sort(temp).ToList();
            }
        }

        protected virtual IEnumerable<string> Sort(IEnumerable<string> preResults)
        {
            return preResults.OrderByDescending(s => s.Length);
        }

        public IEnumerable DoSearch(string searchTerm, int maxResults, object tag)
        {
            ConstructDataSource();
            return _results.Where(term => term.StartsWith(searchTerm)).Take(maxResults);
        }
    }
}
