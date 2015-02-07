using Microsoft.Practices.Prism.PubSubEvents;

namespace Boytrix.UI.Common.Utilities.Behaviours
{
    public class FileDialogArgs 
    {
        public FileDialogArgs(string parm)
        {
            Identifier = string.Empty;
            FullFileName = parm;
        }

        public string Identifier { get; set; }
        public string FullFileName { get; set; }
        public string FileName { get; set; }
    }

    public class FileDialogArgsEvent : PubSubEvent<FileDialogArgs> { }

}
