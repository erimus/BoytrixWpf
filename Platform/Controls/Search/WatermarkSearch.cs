namespace Boytrix.UI.WPF.Libraries.Platform.Controls.Search
{
    public class WatermarkSearch
    {
                public StandardSearchVm WatermarkVM {
            get;
            private set;
        }
        public WatermarkSearch ()
	{
        WatermarkVM = new StandardSearchVm(new SingleColumnResultsProvider());
	}
       
    }
}
