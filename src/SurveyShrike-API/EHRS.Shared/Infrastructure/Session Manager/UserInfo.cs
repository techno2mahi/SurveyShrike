namespace EHRS.Shared
{
    /// <summary>
    /// Represents User Info state entity,
    /// Author		: ATrack
    /// </summary>
    public class UserInfo : StateEntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        public UserInfo()
        {
        }

        public ITokenDTO Token { get; set; }  
   
        /// <summary>
        /// used to save SSP token(ssp admin user), used in Forgot Password Case
        /// </summary>
        public string SspToken { get; set; }
    }
}
