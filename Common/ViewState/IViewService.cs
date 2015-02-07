using System;
using System.Collections.Generic;

namespace Boytrix.Logic.Business.Common.ViewState
{
   public  interface IViewService:ICloneable
    {
        FormMode CurrentVmOperation { get; set; }
        bool HasNoRecords { get; set; }
        bool HasPendingCommits { get; set; }
        Stack<FormMode> ViewMode { get; set; }
        string ViewBackingClass { get; set; }
        string ViewName { get; set; }
        bool IsDirty { get; set; }
       int TabSelectedIndex { get; set; }
       string ToolbarName { get; set; }
       bool ViewExistsFlag { get; set; }//flag to stop duplicates
    }
}
