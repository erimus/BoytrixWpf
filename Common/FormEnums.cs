namespace Boytrix.Logic.Business.Common
{
    public enum FormMode
    {
        ADDMODE,
        EDITMODE,
        DELETEMODE,
        SELECTMODE,
        UNCHANGED,
        SAVED,
        COMMIT,
        REVIEWMODE,
        REFRESHMODE,
        VIEWMODE,
        WIP,
        VALIDATION
    }

    public enum MsgBoxResult
    {
        Abort,
        Cancel,
        Ignore,
        No,
        None,
        OK,
        Retry,
        Yes
    }

    public enum UserAdminTab
    {
        UserBasicInfo,
        UserGroup
    }

}
