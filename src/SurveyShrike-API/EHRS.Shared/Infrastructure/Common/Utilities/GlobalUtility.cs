using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EHRS.Shared
{
    /// <summary>
    /// Provides static utility methods.
    /// Author : ATrack
    /// </summary>
    public static class GlobalUtility
    {
        /// <summary>
        /// The city value.
        /// </summary>
        private const int CityValue = 6;

        /// <summary>
        /// The default radius.
        /// </summary>
        private const int DefaultRadius = 7;

        /// <summary>
        /// Gets the full image path from cdn or web api
        /// </summary>
        /// <param name="serverFileName"></param>
        /// <returns></returns>
        public static string GetPatientMediaPath(string serverFileName)
        {
            return AppConstants.ConfigurationKeys.WebApiBaseUrl + AppConstants.ConfigurationKeys.PatientMediaPath + serverFileName;
        }

        /// <summary>
        /// Get full name with given seperator
        /// </summary>
        /// <param name="populationClass">
        /// The population Class.
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetCityRadius(short? populationClass)
        {
            int retVal = 0;

            switch (populationClass)
            {
                case 1:
                    retVal = GetRadius(1);
                    break;
                case 2:
                    retVal = GetRadius(2);
                    break;
                case 3:
                    retVal = GetRadius(3);
                    break;
                case 4:
                    retVal = GetRadius(4);
                    break;
                case 5:
                    retVal = GetRadius(5);
                    break;
                default:
                    retVal = DefaultRadius * 1000;
                    break;
            }
            return retVal;
        }

        /// <summary>
        /// Checks whether the value is a valid email
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            return value.Contains("@");
        }

        /// <summary>
        /// The get radius.
        /// </summary>
        /// <param name="populationClass">
        /// The population class.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetRadius(short populationClass)
        {
            return ((CityValue - populationClass) * DefaultRadius) * 1000;
        }

        public static string GetFirstName(string Name)
        {

            if (!string.IsNullOrEmpty(Name))
            {
                Name = Regex.Replace(Name, @"\s+", " ");
                return Name.Split(' ').First();
            }

            return "";

        }

        /// <summary>
        /// Gets the Last Name
        /// </summary>
        public static string GetLastName(string Name)
        {

            if (!string.IsNullOrEmpty(Name) && Name.Contains(" "))
            {
                Name = Regex.Replace(Name, @"\s+", " ");
                return Name.Split(' ').Last();
            }

            return "";

        }

        /// <summary>
        /// Split address into address line 1 and address line 2 based on DB column length i.e. 100
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string[] GetAddressLines(string address)
        {
            var add = address.Trim();
            int addressLength = add.Length;
            string[] addresses = new string[2];
            if (addressLength <= 100)
            {
                addresses[0] = add;
                addresses[1] = string.Empty;
            }
            else
            {
                string addressline1 = "";
                string addressline2 = "";
                int current = add.IndexOf(' ');
                int previous = 0;
                while (current >= 0)
                {
                    if (current < 99)
                    {
                        current = add.IndexOf(' ', current + 1);
                        previous = current;
                        continue;
                    }
                    else if(current == 99)
                    {
                        addressline1 = add.Substring(0, current + 1);
                        addresses[0] = addressline1;
                        var add2Length = addressLength - (current + 1) <= 100 ? addressLength - (current + 1) : 100;
                        addressline2 = add.Substring(current + 1, add2Length);
                        addresses[1] = addressline2;
                    }
                    else
                    {
                        addressline1 = add.Substring(0, previous + 1);
                        addresses[0] = addressline1;
                        var add2Length = addressLength - (previous + 1) <= 100 ? addressLength - (previous + 1) : 100;
                        addressline2 = add.Substring(previous + 1, add2Length);
                        addresses[1] = addressline2;
                    }
                }
            }

            return addresses;
        }

        /// <summary>
        /// Gets timestamp
        /// </summary>
        /// <param name="serverFileName"></param>
        /// <returns></returns>
        public static long GetTimestamp(DateTime datetime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            TimeSpan span = (datetime - epoch);
            return (long)span.TotalMilliseconds;
        }


    }
}