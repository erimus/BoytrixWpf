//using Boytrix.Logic.Business.Common;
//using Boytrix.Logic.Business.Common.ViewState;

//namespace Boytrix.UI.WPF.Libraries.Base
//{
//    //public class ButtonVisibiltyState
//    //{
//    //    public bool IsAddVisible { get; set; }
//    //    public bool IsEditVisible { get; set; }
//    //    public bool IsSaveVisible { get; set; }
//    //    public bool IsDeleteVisible { get; set; }
//    //    public bool IsCommitVisible { get; set; }
//    //    public bool IsExitVisible { get; set; }

//    //    public bool IsViewVisible  { get; set; }
//    //    public bool IsRefreshVisible { get; set; }
//    //    public bool IsReviewVisible { get; set; }
//    //}

//    public enum PageType
//    {
//        Start,
//        Display,
//        DataEntry
//    }

//    public class PageDetails
//    {
      
        
//        public PageDetails(string pageName, PageTitle pageTitle, PageType pageType,FormMode formMode,int pageIndex)
//        {
//            PageTitle = pageTitle;
//            PageName = pageName;
//            PageType = pageType;
//            FormMode = formMode;
//            PageIndex = pageIndex;
           
//        }

    
//        public int PageIndex { get; private set; }
//        public FormMode FormMode { get; private set; }
//        public PageTitle PageTitle { get; private set; }
//        public string PageName { get; private set; }
//        public PageType PageType { get; private set; }

//        public ButtonVisibiltyState ButtonVisibilty
//        {
//            get
//            {
//                if (PageType == PageType.Start)
//                {
//                    return new ButtonVisibiltyState
//                    {
//                        IsAddVisible = false,

//                        IsEditVisible = false,
//                        IsSaveVisible = false,
//                        IsDeleteVisible = false,
//                        IsCommitVisible = false,
//                        IsExitVisible = true,

//                        IsViewVisible = false,
//                        IsRefreshVisible = false,
//                        IsReviewVisible = false,

//                    };
//                }

//                if (PageType == PageType.DataEntry)
//                {
//                    return new ButtonVisibiltyState
//                    {
//                        IsAddVisible =  FormMode == FormMode.ADDMODE ,
//                        IsEditVisible = FormMode == FormMode.EDITMODE ,
//                        IsSaveVisible = true,
//                        IsDeleteVisible = true,
//                        IsCommitVisible = true,
//                        IsExitVisible = true,

//                        IsViewVisible = false,
//                        IsRefreshVisible = false,
//                        IsReviewVisible = false,

//                    };

                    
//                }
              
//                    return new ButtonVisibiltyState
//                    {
//                        IsAddVisible = FormMode != FormMode.WIP,

//                        IsEditVisible = FormMode != FormMode.WIP,
//                        IsSaveVisible = false,
//                        IsDeleteVisible = true,
//                        IsCommitVisible = false,
//                        IsExitVisible = true,

//                        IsViewVisible = false,
//                        IsRefreshVisible = true,
//                        IsReviewVisible = true,
//                    };
//                }
//            }
//        }
    
    

//    public enum
//                PageTitle
//    {
//        HomePage,
//        TasksPage,
//        RestorePage,
//        BackupPage,
//        SettingsPage,
//        MetricsPage,
//        SecurityPage,
//        AddGroup,
//        AddUser,
//        UserAdmin,
//        ShippingMethodGridView
//    }

//    public class ViewManagement
//    {
//        public static PageTitle GetPage(string name, FormMode mode)
//        {
//            switch (name)
//            {
//                case "UserBasicInfo":
//                    switch (mode)
//                    {
//                        case FormMode.UNCHANGED:
//                            return PageTitle.UserAdmin;
//                        case FormMode.EDITMODE:
//                            return PageTitle.AddUser;
//                        case FormMode.ADDMODE:
//                            return PageTitle.AddUser;
//                        default:
//                            break;
//                    }
//                    break;
//                case "UserGroup":
//                    switch (mode)
//                    {
//                        case FormMode.UNCHANGED:
//                            return PageTitle.UserAdmin;
//                        case FormMode.EDITMODE:
//                            return PageTitle.AddGroup;
//                        case FormMode.ADDMODE:
//                            return PageTitle.AddGroup;
//                        default:
//                            break;
//                    }
//                    break;
//                case "ShippingMethod":
//                    switch (mode)
//                    {
//                        case FormMode.UNCHANGED:
//                            return PageTitle.ShippingMethodGridView;
//                        case FormMode.EDITMODE:
//                            return PageTitle.ShippingMethodGridView;
//                        case FormMode.ADDMODE:
//                            return PageTitle.ShippingMethodGridView;
//                        default:
//                            break;
//                    }
//                    break;
//            }
//            return PageTitle.HomePage;
//        }
//    }
//}
