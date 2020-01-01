namespace EHRS.Shared
{
    /// <summary>
    /// Interface ITokenDTO
    /// </summary>
    public interface ITokenDTO
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        string AccessToken { get; set; }
        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>The type of the token.</value>
        string TokenType { get; set; }
        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>The expires in.</value>
        int ExpiresIn { get; set; }
        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>The refresh token.</value>
        string RefreshToken { get; set; }
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        string Error { get; set; }
    }
}