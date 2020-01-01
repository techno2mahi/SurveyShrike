using System;
using System.Collections.Generic;
using System.Xml;

namespace EHRS.Shared
{
    /// <summary>
    /// Provides extension utility methods for Date and Time processing,
    /// Author : TMC 
    /// </summary>
    public static class Extensions
    {
        public static bool IsNullOrDefault<T>(this T? value) where T : struct
        {
            return default(T).Equals(value.GetValueOrDefault());
        }

        public static string ElText(this XmlNode node, string elName)
        {
            return node.SelectSingleNode(elName).InnerText;
        }

        public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput : class
        {
            return o == null ? failureValue : evaluator(o);
        }
    }
}