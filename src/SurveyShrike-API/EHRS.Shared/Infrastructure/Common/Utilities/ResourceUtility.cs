﻿namespace EHRS.Shared
{
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// ResourceUtility reads resource constants.
    /// </summary>
    public static class ResourceUtility
    {
        private static ResourceManager ResourceManager = new ResourceManager("Resources.Resource", Assembly.Load("App_GlobalResources"));
        // Todo how to load the Resources from a single place 
        // private static ResourceManager ResourceManager = new ResourceManager("Resources.Resource", Assembly.LoadFrom(FactoryBase.GetAssembliesSourceOutputBinPath() + "App_GlobalResources\\Resource"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCaptionFor(string key)
        {
            string retVal = string.Empty;

            retVal = ResourceManager.GetString(key);

            return retVal;
        }

        /// <summary>
        /// Enum added must have attribute for Display Text Key
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetCaptionFromEnum<TEnum>(TEnum value) where TEnum : new()
        {
            DisplayTextKeyAttribute displayTextKeyAttribute = EnumAttributeUtility<TEnum, DisplayTextKeyAttribute>.GetEnumAttribute(value.ToString());
            return ResourceUtility.GetCaptionFor(displayTextKeyAttribute.Key);
        }
    }
}
