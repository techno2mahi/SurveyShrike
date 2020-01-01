#region Namespace

using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Resources;
using System.Web;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Data;

#endregion

namespace EHRS.Shared
{
    /// <summary>
    /// Provides static utility methods for App Constants
    /// Author : TMC
    /// </summary>
    public static class AppConstantsUtility
    {
        /// <summary>
        /// Returns default value for an appconstant if it is empty
        /// </summary>
        /// <param name="appConstantValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ReadDefaultValueIfEmpty(string appConstantValue, string defaultValue)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(appConstantValue))
            {
                Logger.Instance.LogInfo("AppConstantsUtility.ReadDefaultValueIfEmpty - Unable to find key for : " +
                                        appConstantValue);
                retVal = defaultValue;
            }
            else
            {
                retVal = appConstantValue;
            }

            return retVal;
        }

        /// <summary>
        /// Returns default value for an appconstant if it is empty
        /// </summary>
        /// <param name="appConstantValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ReadDefaultValueIfEmpty<T>(string appConstantValue, T defaultValue)
        {
            T retVal;

            if (string.IsNullOrEmpty(appConstantValue))
            {
                Logger.Instance.LogInfo("AppConstantsUtility.ReadDefaultValueIfEmpty - Unable to find key for : " +
                                        appConstantValue);
                retVal = defaultValue;
            }
            else
            {
                try
                {
                    retVal = (T) Convert.ChangeType(appConstantValue, typeof (T));
                }
                catch (InvalidCastException icex)
                {
                    Logger.Instance.LogInfo("AppConstantsUtility.ReadDefaultValueIfEmpty - Unable to cast : " +
                                            appConstantValue + " to type : " + typeof (T));
                    ExceptionManager.HandleException(icex);
                    retVal = defaultValue;
                }
            }
            return retVal;
        }
    }
}