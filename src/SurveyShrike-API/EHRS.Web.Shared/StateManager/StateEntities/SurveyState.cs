using System.Collections.Generic;

namespace EHRS.Web.Shared
{
    using EHRS.Shared;

    /// <summary>
    /// Represents surveys 
    /// </summary>
    public class SurveyState : StateEntityBase
    {
        /// <summary>
        /// Gets or sets the grades.
        /// </summary>
        public IList<ISurveyDTO> Surveys { get; set; }
    }
}