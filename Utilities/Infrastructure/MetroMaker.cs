//using Boytrix.UI.Common.Utilities.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

//namespace Boytrix.UI.Common.Utilities.Infrastructure
//{
//    public class MetroMaker
//    {
//        private double wrapPanelX = 0;
//        public void DisplayTiles( StackPanel metroStackPanel)
//        {
//            string[] alphabet =  {"a", "b", "c", "d", "e", "f", "g", "h", "i", 
//                                                "j", "k", "l", "m", "n", "o", "p", "q", "r", 
//                                                "s", "t", "u", "v", "w", "x", "y", "z"};

//            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

//            Dictionary<string, string[]> di = new IconsAndPaths().GetIconsAndPaths();

//            foreach (string s in alphabet)
//            {
//                string letter = s;
//                var coll = di.Where(k => k.Key.StartsWith(letter, true, null));


//                int count = coll.Count();

//                if ((count > 0))
//                {
//                    AddTiles(coll, metroStackPanel, letter);
//                }
//            }


//            foreach (string s in numbers)
//            {
//                string letter = s;
//                var coll = di.Where(k => k.Key.StartsWith(letter, true, null));
//                int count = coll.Count();
//                if ((count > 0))
//                {
//                    AddTiles(coll, metroStackPanel, letter);
//                }

//            }
//        }


//        private void AddTiles(IEnumerable<KeyValuePair<string, string[]>> coll,  StackPanel metroStackPanel, string letter)
//        {
//            WrapPanel tileWrapPanel = new WrapPanel();
//            tileWrapPanel.Orientation = Orientation.Vertical;
//            tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
//            // 3 tiles height-wise
//            tileWrapPanel.Height = (110 * 3) + (6 * 3);

//            foreach (KeyValuePair<string, string[]> kvp in coll)
//            {
//                Tile newTile = new Tile();
//                //newTile.ExecutablePath = kvp.Value(1);
//                //newTile.TileIcon.Source = new BitmapImage(new Uri(kvp.Value[1], UriKind.Absolute));
//                newTile.TileTxtBlck.Text = kvp.Key.ToString();
//                newTile.Margin = new Thickness(0, 0, 6, 6);
//                tileWrapPanel.Children.Add(newTile);
//                newTile.Visibility = Visibility.Visible;
                
//            }

//            WrapPanelLocation(letter, tileWrapPanel);
//            metroStackPanel.Children.Add(tileWrapPanel);
//        }

//        //public void AddTiles(string name,  StackPanel metroStackPanel, string letter)
//        //{
//        //    WrapPanel tileWrapPanel = new WrapPanel();
//        //    tileWrapPanel.Orientation = Orientation.Vertical;
//        //    tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
//        //    // 3 tiles height-wise
//        //    tileWrapPanel.Height = (110 * 3) + (6 * 3);


//        //    Tile newTile = new Tile();

//        //    //newTile.TileIcon.Source = new BitmapImage(new Uri(kvp.Value[0], UriKind.Absolute));
//        //    newTile.TileTxtBlck.Text = name;
//        //    newTile.Margin = new Thickness(0, 0, 6, 6);
//        //    tileWrapPanel.Children.Add(newTile);


//        //    WrapPanelLocation(letter, tileWrapPanel);
//        //    metroStackPanel.Children.Add(tileWrapPanel);
//        //}

//        /// <summary>
//        /// Determines the probable location of a WrapPanel that is added
//        /// to MetroStackPanel (assuming that MetroStackPanel was
//        /// like a Canvas).
//        /// </summary>
//        /// <param name="letter">The alphabetical letter representing a WrapPanel group
//        /// in MetroStackPanel.</param>
//        /// <param name="tileWrapPanel">The WrapPanel that was added to MetroStackPanel.</param>
//        /// <remarks></remarks>
//        private void WrapPanelLocation(string letter, WrapPanel tileWrapPanel)
//        {
//            if ((QuickJumper.WrapPanelDi.Count == 0))
//            {
//                QuickJumper.WrapPanelDi.Add(letter, 0);
//            }
//            else
//            {
//                QuickJumper.WrapPanelDi.Add(letter, wrapPanelX);
//            }

//            // Increase value of wrapPanelX as appropriate. 
//            // 6 is right margin of a Tile. 
//            if ((tileWrapPanel.Children.Count <= 3))
//            {
//                wrapPanelX += ((110 + 6) + 18);
//            }
//            else
//            {
//                double numberOfColumns = Math.Ceiling((double)tileWrapPanel.Children.Count / 3);
//                double x = (numberOfColumns * 110) + (numberOfColumns * 6) + 18;
//                wrapPanelX += x;
//            }
//        }
//    }
//}
