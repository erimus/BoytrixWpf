using System;
using System.Windows;
using Boytrix.UI.Common.Utilities;
using Boytrix.UI.WPF.Libraries.Base;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Boytrix.Logic.Business.Common.ViewState;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigation
{
    public class NavigationRegion
    {
        public static string GetRegionName(DependencyObject obj)
        {
            return (string) obj.GetValue(RegionNameProperty);
        }

        public static void SetRegionName(DependencyObject obj, string value)
        {
            obj.SetValue(RegionNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for RegionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.RegisterAttached("RegionName", typeof (string), typeof (NavigationRegion),
                new PropertyMetadata(String.Empty, OnRegionNameChanged));

        private static void OnRegionNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as FrameworkElement;
            if (control != null)
            {
                NavigationRepo.Regions.Add(new RegionManager(control));
            }
        }

    }

    public class ViewShower<T> where T:FrameworkElement
    {
        internal static void ShowView(IRegion region, IUnityContainer container)
        {
            foreach (var view in region.Views)
            {
                if (view != null)
                {
                    var v = view as T;
                    if (v != null)
                    {
                        region.Activate(view);

                        var vw = container.Resolve<IViewService>();
                        vw.ViewName = view.ToString();
                        vw.ViewExistsFlag = true;
                        return;
                    }
                }
            }
            region.RegionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion,
                
                //typeof (T));
                () => container.Resolve<T>());
            //region.RegionManager.Regions[RegionNames.WorkspaceRegion].Activate(vew);

            foreach (var view in region.Views)
            {
                if (view != null)
                {
                    var v = view as T;
                    if (v != null)
                    {
                        region.Activate(view);

                        var vw = container.Resolve<IViewService>();
                        vw.ViewName = view.ToString();
                        return;
                    }
                }
            }

        }
    }


    public class RemoveView<T> where T : FrameworkElement
    {
        internal static void ShowView(IRegion region, IUnityContainer container)
        {
            foreach (var view in region.Views)
            {
                if (view != null)
                {
                    var v = view as T;
                    if (v != null)
                    {
                        region.Remove(view);
                        return;
                    }
                }
            }
            //region.RegionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion,
            //    () => container.Resolve<T>());
            ////region.RegionManager.Regions[RegionNames.WorkspaceRegion].Activate(vew);

            //foreach (var view in region.Views)
            //{
            //    if (view != null)
            //    {
            //        var v = view as T;
            //        if (v != null)
            //        {
            //            region.Activate(view);
            //            return;
            //        }
            //    }
            //}

        }
    }
}
