
//using System;
//using System.Collections.Generic;
//using Boytrix.Logic.Business.Common;
//using Microsoft.Practices.Prism.PubSubEvents;

//namespace Boytrix.UI.WPF.Libraries.Base
//{
//    public class SaveModeArgs : VmMessage
//    {
//        public string ViewName { get; set; }
//        public FormMode FormState { get; set; }

//        public override FormMode Vmode
//        {
//            get { return FormMode.SAVED; }
//        }
//    }

//    public class SaveModeArgsEvent : PubSubEvent<SaveModeArgs>
//    {
//    }

//    public class ViewService : IViewService
//    {
//        public string ViewBackingClass { get; set; }
//        public Stack<FormMode> ViewMode { get; set; }
//        public bool HasPendingCommits { get; set; } //used to set commit button on or off
//        public FormMode CurrentVmOperation { get; set; }
//        public bool HasNoRecords { get; set; }
//        public Uri CurrentUri { get; set; }
//        public Uri PreviousUri { get; set; }
//        public Uri NextUri { get; set; }
//        public string ViewName { get; set; }
       

//        public object Clone()
//        {
//            return MemberwiseClone();
//        }
//    }

//    public abstract class VmMessage
//    {
//        protected object val;

//        public void SetRow<T>(T row) where T : class
//        {
//            val = row;
//        }
//        public T GetRow<T>() where T : class
//        {
//            return val as T;
//        }
//        public abstract FormMode Vmode { get; }
//    }

//    public class VmOnLoad : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.UNCHANGED; }
//        }
//    }

//    public class VmOnAdd : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.ADDMODE; }
//        }
//    }

//    public class VmOnEdit : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.EDITMODE; }
//        }
//    }

//    public class VmOnDelete : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.DELETEMODE; }
//        }

//    }

//    public class VmOnView : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.UNCHANGED; }
//        }
//    }

//    public class VmOnReview : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.REVIEWMODE; }
//        }
//    }

//    public class VmOnSelect : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.SELECTMODE; }
//        }
//    }

//    public class VmOnSave : VmMessage
//    {
//        public VmOnSave(FormMode vmMode)
//        {
//            CurrentMode = vmMode;
//        }
//        public override FormMode Vmode
//        {
//            get { return FormMode.SAVED; }
           
//        }
//        public FormMode CurrentMode { get; private set; }
//    }

//    public class VmOnCommit : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.COMMIT; }
//        }
//    }


//    public class VmOnRefresh : VmMessage
//    {
//        public override FormMode Vmode
//        {
//            get { return FormMode.REFRESHMODE; }
//        }
//    }

//     public class RecordMoveFirst {  }
//        public class RecordMoveNext {  }
//        public class RecordMovePrevious { }
//        public class RecordMoveLast { }

//        public class RecordMoveFirstEvent : PubSubEvent<RecordMoveFirst>
//        {
//        }
//        public class RecordMoveNextEvent : PubSubEvent<RecordMoveNext>
//        {
//        }
//        public class RecordMovePreviousEvent : PubSubEvent<RecordMovePrevious>
//        {
//        }
//        public class RecordMoveLastEvent : PubSubEvent<RecordMoveLast>
//        {
//        }

//    public class VmOnAddEvent : PubSubEvent<VmOnAdd>
//    {
//    }

//    public class VmOnEditEvent : PubSubEvent<VmOnEdit>
//    {
//    }

//    public class VmOnViewEvent : PubSubEvent<VmOnView>
//    {
//    }

//    public class VmOnDeleteEvent : PubSubEvent<VmOnDelete>
//    {
//    }

//    public class VmOnReviewEvent : PubSubEvent<VmOnReview>
//    {
//    }

//    public class VmOnSelectEvent : PubSubEvent<VmOnSelect>
//    {
//    }


//    public class VmOnSaveEvent : PubSubEvent<VmOnSave>
//    {
//    }

//    public class VmOnCommitEvent : PubSubEvent<VmOnCommit>
//    {
//    }
//    public class VmOnLoadEvent : PubSubEvent<VmOnLoad>
//    {
//    }
//    public class VmOnRefreshEvent : PubSubEvent<VmOnRefresh>
//    {
//    }
//}

