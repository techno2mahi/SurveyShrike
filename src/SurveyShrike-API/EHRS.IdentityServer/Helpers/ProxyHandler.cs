using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EHRS.IdentityServer.Helpers
{
    public class ProxyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestString = request.RequestUri.ToString();

            if (requestString.EndsWith(".txt"))
            {
                var newUri = requestString.Substring(0, requestString.Length - 4);
                request.RequestUri = new Uri(newUri, UriKind.Absolute);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            }
            return base.SendAsync(request, cancellationToken);
        }

    }
}