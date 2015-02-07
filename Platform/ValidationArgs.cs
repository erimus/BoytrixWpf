using Microsoft.Practices.Prism.PubSubEvents;
using MvvmValidation;

namespace Boytrix.UI.WPF.Libraries.Platform
{
    public class ValidationArgs
    {
        public ValidationErrorCollection Validation { get; set; }
    }
    // Create an Event
    public class ValidationArgsEvent : PubSubEvent<ValidationArgs> { }
    
}
