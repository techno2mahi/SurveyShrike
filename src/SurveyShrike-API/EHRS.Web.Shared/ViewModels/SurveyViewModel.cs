using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHRS.Web.Shared.ViewModels
{
    /// <summary>
    /// The Survey View Model.
    /// </summary>
    public class SurveyViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string SurveyTitle { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy.
        /// </summary>
        public string ModifiedBy { get; set; }

        // todo add the FormFieldsViewModel
    }
}