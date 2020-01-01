using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EHRS.Shared
{
    /// <summary>
    /// Defines a contract for Logger,
    /// Author		: TMC
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInfo(object message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarning(object message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message.</param>        
        void LogDebug(object message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message.</param>        
        void LogError(object message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void LogError(object message, Exception exception);
    }
}
