using Boytrix.Logic.Business.Common.State;

namespace Boytrix.Logic.Business.Common.ViewState
{
    //public class ButtonVisibiltyState
    //{
    //    public bool IsAddVisible { get; set; }
    //    public bool IsEditVisible { get; set; }
    //    public bool IsSaveVisible { get; set; }
    //    public bool IsDeleteVisible { get; set; }
    //    public bool IsCommitVisible { get; set; }
    //    public bool IsExitVisible { get; set; }

    //    public bool IsViewVisible  { get; set; }
    //    public bool IsRefreshVisible { get; set; }
    //    public bool IsReviewVisible { get; set; }
    //}

    public enum PageType
    {
        Start,
        Display,
        DataEntry
    }

    public class PageDetails
    {
        

        public PageDetails(string pageName, PageTitle pageTitle, PageType pageType, FormMode formMode)
        {
            PageTitle = pageTitle;
            PageName = pageName;
            PageType = pageType;
            FormMode = formMode;
         

        }
        public PageDetails(string pageName, PageTitle pageTitle, PageType pageType, FormMode formMode, int pageIndex, VmStateContext vmState)
        {
            PageTitle = pageTitle;
            PageName = pageName;
            PageType = pageType;
            FormMode = formMode;
            PageIndex = pageIndex;
            //VmStateContext = vmState;
        }
        public PageDetails(string pageName, PageTitle pageTitle, PageType pageType, VmStateContext vmState)
        {
            PageTitle = pageTitle;
            PageName = pageName;
            PageType = pageType;
            //VmStateContext = vmState;
        }
        public PageDetails(int pageIndex, object view, ButtonVisibiltyState currentState)
        {
            PageIndex = pageIndex;
            View = view;
            ButtonState = currentState;
        }
        public int PageIndex { get; private set; }
        public FormMode FormMode { get; private set; }
        public PageTitle PageTitle { get; private set; }
        public string PageName { get; private set; }
        public PageType PageType { get; private set; }
        public object View { get; private set; }
        public ButtonVisibiltyState ButtonState { get; private set; }
       // public ButtonVisibiltyState ButtonVisibilty { get; set; }
       
        }



    public enum
                PageTitle
    {
        HomePage,
        TasksPage,
        RestorePage,
        BackupPage,
        SettingsPage,
        MetricsPage,
        SecurityPage,
        AddGroup,
        AddUser,
        UserAdmin,
        ShippingMethodGridView,
        ShippingMethod,
        AddShippingMethod,
        OpenOrders
    }

    public class ViewManagement
    {
        public static PageTitle GetPage(string name, FormMode mode)
        {
            switch (name)
            {
                case "UserBasicInfo":
                    switch (mode)
                    {
                        case FormMode.UNCHANGED:
                            return PageTitle.UserAdmin;
                        case FormMode.EDITMODE:
                            return PageTitle.AddUser;
                        case FormMode.ADDMODE:
                            return PageTitle.AddUser;
                        case FormMode.VIEWMODE:
                            return PageTitle.AddUser;
                        default:
                            break;
                    }
                    break;
                case "UserGroup":
                    switch (mode)
                    {
                        case FormMode.UNCHANGED:
                            return PageTitle.UserAdmin;
                        case FormMode.EDITMODE:
                            return PageTitle.AddGroup;
                        case FormMode.ADDMODE:
                            return PageTitle.AddGroup;
                        case FormMode.VIEWMODE:
                            return PageTitle.AddUser;
                        default:
                            break;
                    }
                    break;
                case "ShippingMethod":
                    switch (mode)
                    {
                        case FormMode.UNCHANGED:
                            return PageTitle.ShippingMethodGridView;
                        case FormMode.EDITMODE:
                            return PageTitle.ShippingMethodGridView;
                        case FormMode.ADDMODE:
                            return PageTitle.AddShippingMethod;
                        case FormMode.VIEWMODE:
                            return PageTitle.AddShippingMethod;
                        default:
                            break;
                    }
                    break;
                case "Order":
                    switch (mode)
                    {
                        case FormMode.UNCHANGED:
                            return PageTitle.OpenOrders;
                        case FormMode.EDITMODE:
                            return PageTitle.OpenOrders;
                        case FormMode.ADDMODE:
                            return PageTitle.OpenOrders;
                        case FormMode.VIEWMODE:
                            return PageTitle.OpenOrders;
                        default:
                            break;
                    }
                    break;
            }
            return PageTitle.HomePage;
        }
    }
}
