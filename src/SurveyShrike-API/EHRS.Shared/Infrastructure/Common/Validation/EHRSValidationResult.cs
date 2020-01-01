using System.Collections.Generic;


namespace EHRS.Shared 
{
    public class EHRSValidationResult
    {
        public IList<EHRSValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public EHRSValidationResult(IList<EHRSValidationFailure> failures)
        {
            Errors = failures;
        }

        public EHRSValidationResult()
        {
            Errors = new List<EHRSValidationFailure>();
        }
    }
}