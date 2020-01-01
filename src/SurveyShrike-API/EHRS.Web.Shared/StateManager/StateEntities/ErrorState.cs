using EHRS.Shared;

namespace EHRS.Web.Shared
{
    /// <summary>
    /// Represents error information.
    /// </summary>
    public class ErrorState : StateEntityBase
    {
        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }
    }
}