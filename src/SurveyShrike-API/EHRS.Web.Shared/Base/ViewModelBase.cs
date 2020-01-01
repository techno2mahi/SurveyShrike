using System;

namespace EHRS.Web.Shared
{
    /// <summary>
    /// The view model base class.
    /// </summary>
    public class ViewModelBase
    { 
        /// <summary>
        /// Gets or sets date time item is being created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets date time when item is being last updated
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets detail of user by whom item is last updated
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets detail of user by whom item is created
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The user id of the user
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        ///  Gets or sets if the item is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// /// <summary>
        ///  Gets or sets if the item is deleted
        /// </summary>
        /// </summary>
        public bool IsDeleted { get; set; } 
    }
}