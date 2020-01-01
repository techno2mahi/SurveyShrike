using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace EHRS.Web.Shared.Common
{
    /// <summary>
    /// Provides extension utility methods for string processing,
    /// Author : TMC 
    /// </summary>
    public static class StringExtensions
    {
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// This function uses dictionary to find a key in the string and replace it with the corresponding dictionary value 
        /// </summary>
        /// <param name="format">string containing the keys that is to be updated</param>
        /// <param name="dictionary">dictionary containing the key/value pairs</param>
        /// <param name="regexStart">prefix for creating regex from key</param>
        /// <param name="regexEnd">suffix for creating regex from key</param>
        /// <returns></returns>
        public static string Inject(this string format, IDictionary dictionary, string regexStart, string regexEnd)
        {
            return format.Inject(new Hashtable(dictionary), regexStart, regexEnd);
        }       

        /// <summary>
        /// This function uses Hashtable to find a key in the string and replace it with the corresponding value 
        /// </summary>
        /// <param name="format">string containing the keys that is to be updated</param>
        /// <param name="attributes">Hashtable containing the key/value pairs</param>
        /// <param name="regexStart">prefix for creating regex from key</param>
        /// <param name="regexEnd">suffix for creating regex from key</param>
        /// <returns></returns>
        private static string Inject(this string format, Hashtable attributes, string regexStart, string regexEnd)
        {
            string result = format;
            if (attributes == null || format == null)
                return result;

            foreach (string attributeKey in attributes.Keys)
            {
                result = result.InjectSingleValue(attributeKey, attributes[attributeKey], regexStart, regexEnd);
            }
            return result;
        }

        /// <summary>
        /// This function finds all ocurrences of a key in string and replaces it with the corresponding value to update the string 
        /// </summary>
        /// <param name="format">string containing the keys that is to be updated</param>
        /// <param name="key">key to be found in string</param>
        /// <param name="replacementValue">value with which key has to be replaced</param>
        /// <param name="regexStart">prefix for creating regex from key</param>
        /// <param name="regexEnd">suffix for creating regex from key</param>
        /// <returns></returns>
        private static string InjectSingleValue(this string format, string key, object replacementValue,
                                                string regexStart, string regexEnd)
        {
            string result = format;
            //regex replacement of key with value
            Regex attributeRegex = new Regex(regexStart + key + regexEnd);

            //loop through matches, since each key may be used more than once
            foreach (Match m in attributeRegex.Matches(format))
            {
                string replacement = m.ToString();
                replacement = (replacementValue ?? string.Empty).ToString();
                //perform replacements, one match at a time
                result = result.Replace(m.ToString(), replacement);
            }
            return result;
        }
    }
}