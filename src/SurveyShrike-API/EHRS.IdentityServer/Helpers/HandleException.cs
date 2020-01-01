using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHRS.IdentityServer.Helpers
{
    /// <summary>
    /// The base Exception Class
    /// </summary>
    public class HandleException : Exception
    {
        public HandleException(string message)
            : base(message)
        {

        }
    }
}