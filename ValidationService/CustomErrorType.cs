namespace ValidationService
{
    public class CustomErrorType
    {
        public CustomErrorType(string validationMessage, Severity severity)
        {
            ValidationMessage = validationMessage;
            Severity = severity;
        }

        public string ValidationMessage { get; private set; }
        public Severity Severity { get; private set; }
    }

    public enum Severity
    {
        WARNING,
        ERROR
    }
}