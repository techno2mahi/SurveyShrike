
namespace EHRS.Shared
{
    #region Namespaces
    using System;
    using System.Security.Cryptography;

    #endregion

    /// <summary>
    /// Utility For generating random password
    /// </summary>
    public class RandomNumberGenerationUtility
    {
        #region Public Methods

        /// <summary>
        /// To generate random password
        /// </summary>
        /// <returns></returns>
        public static string GeneratePassword()
        {
            // Define default password length.
            int passwordLength = 8;
            //No characters that are confusing: i, I, l, L, o, O, 0, 1, u, v
            string passwordCharacters = "abcdefghjkmnpqrstwxyzABCDEFGHJKMNPQRSTWXYZ23456789*$_&=!%";

            var password = new char[passwordLength];

            var random = GetRandom();

            for (int i = 0; i < passwordLength; i++)
                password[i] = passwordCharacters[random.Next(passwordCharacters.Length)];

            return new string(password);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets a random object with a real random seed
        /// </summary>
        /// <returns></returns>
        private static Random GetRandom()
        {
            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            new RNGCryptoServiceProvider().GetBytes(randomBytes);

            // Convert 4 bytes into a 32-bit integer value.
            int seed = (randomBytes[0] & 0x7f) << 24 |
                       randomBytes[1] << 16 |
                       randomBytes[2] << 8 |
                       randomBytes[3];

            // Now, this is real randomization.
            return new Random(seed);
        }
        #endregion
    }
}
