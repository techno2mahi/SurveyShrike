using System;
using EHRS.Shared;

namespace EHRS.Shared
{
    /// <summary>
    /// Contract for Survey DTO .
    /// </summary>
    /// <seealso cref="EHRS.Shared.DTOBase" />
    /// <seealso cref="EHRS.Shared.ISurveyDTO" />
    public interface ISurveyDTO : IDTO
    {

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        string SurveyTitle { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn.
        /// </summary>
        DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy.
        /// </summary>
        string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}