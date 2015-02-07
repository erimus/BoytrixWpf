using System.Collections.Generic;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    internal class NavigationRepo
    {
        static NavigationRepo()
        {
            Regions = new List<RegionManager>();
        }

        internal static readonly List<RegionManager> Regions;
    }
}
