namespace EHRS.Shared
{
    /// <summary>
    /// The IAppSettingsDTO interface
    /// </summary>
    public interface IAppSettingsDTO : IDTO
    {
        /// <summary>
        /// Gets or sets the service base.
        /// </summary>
        /// <value>The service base.</value>
        string ServiceBase { get; set; } 
    }
}
