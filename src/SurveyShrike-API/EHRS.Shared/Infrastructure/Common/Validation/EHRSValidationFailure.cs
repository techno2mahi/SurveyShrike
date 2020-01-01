namespace EHRS.Shared 
{
    public class EHRSValidationFailure
    {
        public object AttemptedValue { get; private set; }
        public object CustomState { get; set; }
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; set; }

        public  EHRSValidationFailure(string propertyName, string error)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
        }

        public EHRSValidationFailure(string propertyName, string error, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
            AttemptedValue = attemptedValue;
        }
    }
}
