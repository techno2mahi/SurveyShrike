using System;

namespace EHRS.Web.Shared.ViewModels
{
    /// <summary>
    /// The FormFi View Model.
    /// </summary>

    public class FormFieldViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Gets or sets the FormTypes.
        /// </summary>
        public int FormTypes { get; set; }

        /// <summary>
        /// Gets or sets the FormConfiguration.
        /// </summary>
        public string FormConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the SurveyId.
        /// </summary>
        public int? SurveyId { get; set; }
    }
}