using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public static class NavigationService
    {
        public static void NavigateTo(string regionName, FrameworkElement view)
        {
            var regionManager = NavigationRepo.Regions.FirstOrDefault(t => NavigationRegion.GetRegionName(t.Region) == regionName);
            if (regionManager != null)
            {
                AdaptView(view, regionManager);
                regionManager.Views.Push(view);
            }
        }

        private static void AdaptView(FrameworkElement view, RegionManager regionManager)
        {
            if (regionManager.Region is ContentControl)
            {
                ((ContentControl)regionManager.Region).Content = view;
            }
            else if (regionManager.Region is ItemsControl)
            {
                ((ItemsControl)regionManager.Region).Items.Add(view);
            }
            else
            {
                throw new InvalidOperationException("The container is not a vaild region.");
            }
        }

        public static void GoBack(string regionName)
        {
            var regionManager = NavigationRepo.Regions.FirstOrDefault(t => NavigationRegion.GetRegionName(t.Region) == regionName);
            if (regionManager != null)
            {
                regionManager.Views.Pop();
                var view = regionManager.Views.Peek();
                AdaptView(view, regionManager);
            }
        }

        public static bool CanGoBack(string regionName)
        {
            var regionManager = NavigationRepo.Regions.FirstOrDefault(t => NavigationRegion.GetRegionName(t.Region) == regionName);
            if (regionManager != null)
            {
                return regionManager.Views.Count() > 1;
            }
            return false;
        }

        public static void ClearViews(string regionName)
        {
            var regionManager = NavigationRepo.Regions.FirstOrDefault(t => NavigationRegion.GetRegionName(t.Region) == regionName);
            if (regionManager != null)
            {
                regionManager.Views.Clear();
                if (regionManager.Region is ContentControl)
                {
                    ((ContentControl)regionManager.Region).Content = null;
                }
                else if (regionManager.Region is ItemsControl)
                {
                    ((ItemsControl)regionManager.Region).Items.Clear();
                }
                else
                {
                    throw new InvalidOperationException("The container is not a vaild region.");
                }
            }
        }
    }
}
