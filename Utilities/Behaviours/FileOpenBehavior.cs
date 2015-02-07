using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;

namespace Boytrix.UI.Common.Utilities.Behaviours
{
    public class FileOpenBehavior : Behavior<Button>
    {
        // Properties - can be set from XAML
        public string MessageIdentifier { get; set; }
        public string Filter { get; set; }
        public bool MultiSelect { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            Filter = "Image files (*.bmp, *.jpg)|*.bmp;*.jpg|Doc Files (*.doc;*.docx)|*.doc;*.docx";
           
            AssociatedObject.Click += AssociatedObject_Click;
        }

        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            // Open the dialog and send the message
            var dialog =
              new OpenFileDialog { Filter = Filter, Multiselect = MultiSelect };
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == true)
            {
                var msg= new FileDialogArgs(dialog.FileName) ;
                msg.Identifier = MessageIdentifier;
                msg.FileName=dialog.SafeFileName;
                var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

                eventAggregator.GetEvent<FileDialogArgsEvent>().Publish(msg);
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
            base.OnDetaching();
        }
    }

}
