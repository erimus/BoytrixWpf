using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using Boytrix.Logic.DataTransfer.Model;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Boytrix.UI.Common.Utilities.EventMessages
{
    public class CloseViewMessage
    {
        public string ViewName { get; set; }
    }

    public class ViewArgs
    {
        public string ViewName{get;set;}
        public bool CanAdd{get;set;}
        public bool CanSave{get;set;}
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }

        public string ViewFriendlyName { get; set; }
    }

   
    public class NotificationMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
    public class AddModeArgs
    {
        public string ViewName { get; set; }
    }

    public class EditModeArgs
    {
        public string ViewName { get; set; }
    }

    public class DeleteModeArgs
    {
        public string ViewName { get; set; }
    }

   

    public class ViewModeArgs
    {
        public string ViewName { get; set; }
       
    }

    public class RefreshModeArgs
    {
        public string ViewName { get; set; }
    }

    public class CommitModeArgs
    {
        public string ViewName { get; set; }
    }

    public class ReviewModeArgs
    {
        public string ViewName { get; set; }
    }

    public class SearchModeArgs
    {
        public string SearchValue { get; set; }
    }

    // Create an Event
    public class CloseViewEvent : PubSubEvent<CloseViewMessage> { }

    public class OpenViewMessage
    {
        public string ViewName { get; set; }

    }

    public class ClearViewControls
    {
    }

    public class AddUserGroup
    {
        public UserGroup UserGroup { get; set; }
    }

    public class SelectedTabArgs
    {
        public string BackingClass { get; set; }
    }
   
    public class OpenViewEvent : PubSubEvent<OpenViewMessage> { }

    /// </summary>
    public class NavigationCompletedEvent : PubSubEvent<string>
    {
    }

    public class SelectedTabArgsEvent : PubSubEvent<SelectedTabArgs> { }
    public class AddUserGroupEvent : PubSubEvent<AddUserGroup> { }
    public class ViewArgsEvent : PubSubEvent<ViewArgs> { }
    public class AddModeArgsEvent : PubSubEvent<AddModeArgs> { }
    public class EditModeArgsEvent : PubSubEvent<EditModeArgs> { }
    
    public class DeleteModeArgsEvent : PubSubEvent<DeleteModeArgs> { }
    public class ViewModeArgsEvent : PubSubEvent<ViewModeArgs> { }
   
    public class RefreshModeArgsEvent : PubSubEvent<RefreshModeArgs> { }
    public class CommitModeArgsEvent : PubSubEvent<CommitModeArgs> { }
    public class ReviewModeArgsEvent : PubSubEvent<ReviewModeArgs> { }
    public class NotificationMessageEvent : PubSubEvent<NotificationMessage> { }

    public class SearchModeArgsEvent : PubSubEvent<SearchModeArgs> { }
    public class ClearViewControlsEvent : PubSubEvent<ClearViewControls> { }

    
    
}