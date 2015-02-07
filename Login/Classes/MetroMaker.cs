
//using Boytrix.Logic.Model.Classes.UserData;
//using Boytrix.UI.WPF.BoytrixModules.Login.Views;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

//namespace Boytrix.UI.WPF.BoytrixModules.Login.Classes
//{
//    public class MetroMaker
//    {
//        public event EventHandler<SecurityPermissionArgs> ExecuteProgram;
//        private double wrapPanelX = 0;
//        public void DisplayTiles( StackPanel metroStackPanel, IList<SecurityPermission> perms)
//        {
//            string[] alphabet =  {"a", "b", "c", "d", "e", "f", "g", "h", "i", 
//                                                "j", "k", "l", "m", "n", "o", "p", "q", "r", 
//                                                "s", "t", "u", "v", "w", "x", "y", "z"};

//            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };


//            //foreach (var j in perms)
//            //{
                
//            //    var coll = perms.Where(k => k.Name.StartsWith(letter, true, null));


//            //    int count = coll.Count();

//            //    if ((count > 0))
//            //    {
//            //        AddTiles(perms, metroStackPanel, letter);
//            //    }
//            //}




//            Dictionary<string, string[]> di = new IconsAndPaths().GetIconsAndPaths();

//            int count = di.Count();
//            int p = 0;
//            for (int i = 0; i < count; i++)
//            {
//                if ((i % 10) == 0)
//                {
//                    var j = perms.Where(x => x.ID > p && x.ID < i || x.ID==i).ToList();
//                    //x > p && x<i || x=i)
//                    AddTiles(j, metroStackPanel, i.ToString());
//                    p++;
//                }
//            }

//            //foreach (string s in alphabet)
//            //{
//            //    string letter = s;
//            //    var coll = perms.Where(k => k.Name.StartsWith(letter, true, null));


//            //    int count = coll.Count();

//            //    if ((count > 0))
//            //    {
//            //        AddTiles(perms, metroStackPanel, letter);
//            //    }
//            //}


//            //foreach (string s in numbers)
//            //{
//            //    string letter = s;
//            //    var coll = perms.Where(k => k.Name.StartsWith(letter, true, null));
//            //    int count = coll.Count();
//            //    if ((count > 0))
//            //    {
//            //        AddTiles(perms, metroStackPanel, letter);
//            //    }

//            //}
//        }


//        private void AddTiles(IList<SecurityPermission> coll, StackPanel metroStackPanel, string letter)
//        {
//            WrapPanel tileWrapPanel = new WrapPanel();
//            tileWrapPanel.Orientation = Orientation.Vertical;
//            tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
//            // 3 tiles height-wise
//            tileWrapPanel.Height = (110 * 3) + (6 * 3);

//            foreach ( var kvp in coll)
//            {
//                Tile newTile = new Tile();
//                newTile.ProgramId = kvp.ID;
//                newTile.ProgramName = kvp.Name;
//                newTile.SecurityId = kvp.SecurityID;
//                newTile.Description = kvp.Desc;
//                newTile.ProgramClicked += newTile_ProgramClicked;     
//                //newTile.ExecutablePath = kvp.Value(1);
//                //newTile.TileIcon.Source = new BitmapImage(new Uri(kvp.Value[1], UriKind.Absolute));
//                newTile.TileTxtBlck.Text = kvp.Name.ToString();
//                newTile.Margin = new Thickness(0, 0, 6, 6);
//                tileWrapPanel.Children.Add(newTile);
//                newTile.Visibility = Visibility.Visible;
                
//            }

//            WrapPanelLocation(letter, tileWrapPanel);
//            metroStackPanel.Children.Add(tileWrapPanel);
//        }

//        void newTile_ProgramClicked(object sender, SecurityPermissionArgs e)
//        {
//            EventHandler<SecurityPermissionArgs> handler = ExecuteProgram;
//            if (handler != null)
//            {
//                handler(this, e);
//            }
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
//        /// 


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
