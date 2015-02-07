using System.Collections.Generic;
using System.Windows;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public class RegionManager
    {
        public FrameworkElement Region;

        public Stack<FrameworkElement> Views;

        public RegionManager(FrameworkElement region)
        {
            Region = region;
            Views = new Stack<FrameworkElement>();
        }
    }
}
