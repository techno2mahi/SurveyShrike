
namespace EHRS.Web.Shared.ViewModels
{
    /// <summary>
    /// View model for wizard step
    /// </summary>
    public class WizardStepViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardStepViewModel"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public WizardStepViewModel(string displayName, string controller, string action, object routeValues)
        {
            this.DisplayName = displayName;
            this.Controller = controller;
            this.Action = action;
            this.RouteValues = routeValues;
        }

        #endregion 

        #region Public Members

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        public string Controller { get; private set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; private set; }

        /// <summary>
        /// Gets or sets the route values.
        /// </summary>
        /// <value>
        /// The route values.
        /// </value>
        public object RouteValues { get; private set; }

        #endregion

    }
}
