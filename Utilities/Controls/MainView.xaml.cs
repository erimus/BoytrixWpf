using Boytrix.UI.Common.Utilities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Boytrix.UI.Common.Utilities.Controls
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {

            private double initMouseX;
            private double finalMouseX;
            private double x;
            private double newX;
            private DispatcherTimer timer;
            private DoubleAnimationUsingKeyFrames anim;

            public MainView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MetroMaker metro = new MetroMaker();
            metro.DisplayTiles(MetroStackPanel);

            string path = "/Themes/GreenSkin.xaml";
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri(path, UriKind.Relative);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newDictionary);
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            timer = new DispatcherTimer();
            anim = new DoubleAnimationUsingKeyFrames();

            anim.Duration = TimeSpan.FromMilliseconds(1800);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += timer_Tick;
        }


        // Check whether the StackPanel is no longer in view and
        // return it to a suitable postion.
        private void timer_Tick(object sender, EventArgs e)
        {
            double mspWidth = MetroStackPanel.ActualWidth;

            if ((newX > 200))
            {
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(45, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            else if (((newX + mspWidth) < 500))
            {
                double widthX = 500 - (newX + mspWidth);
                double shiftX = newX + widthX;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(shiftX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            timer.Stop();
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            // Move MetroStackPanel so that the WrapPanel with the 
        // required alphabetical group is displayed first.
            QuickJumper.ShiftStackPanel(e.Key.ToString(), MetroStackPanel);
        }

        private void MainCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
              initMouseX = e.GetPosition(MainCanvas).X;
              x = Canvas.GetLeft(MetroStackPanel);
        }

        private void MainCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            finalMouseX = e.GetPosition(MainCanvas).X;
            double diff = Math.Abs(finalMouseX - initMouseX);

            // Make sure the diff is substantial so that tiles 
            // don't scroll on double-click.
            if ((diff > 5))
            {
                if ((finalMouseX < initMouseX))
                {
                    newX = x - (diff * 2);
                }
                else if ((finalMouseX > initMouseX))
                {
                    newX = x + (diff * 2);
                }

                anim.KeyFrames.Add(new SplineDoubleKeyFrame(newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
                timer.Start();
            }

        }

        Point currentPoint;
        bool isInDrag = false;
        Point anchorPoint;
        private void MainBgrndRct_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isInDrag)
            {
                var element = sender as FrameworkElement;
                currentPoint = e.GetPosition(null);

                transform.X += currentPoint.X - anchorPoint.X;
                transform.Y += (currentPoint.Y - anchorPoint.Y);
                this.RenderTransform = transform;
                anchorPoint = currentPoint;
            }
        }

        private TranslateTransform transform = new TranslateTransform();
      
    }
}
