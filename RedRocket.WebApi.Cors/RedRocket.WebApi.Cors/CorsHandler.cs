using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RedRocket.WebApi.Cors
{
    /// <summary>
    /// Author:  Carlos Figueira
    /// Code is from http://code.msdn.microsoft.com/CORS-support-in-ASPNET-Web-01e9980a/sourcecode?fileId=60420&pathId=1908491756
    /// All credit is his, I got sick of deploying this class over and over.
    /// </summary>
    public class CorsHandler : DelegatingHandler
    {
        const string Origin = "Origin";
        const string AccessControlRequestMethod = "Access-Control-Request-Method";
        const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isCorsRequest = request.Headers.Contains(Origin);
            var isPreflightRequest = request.Method == HttpMethod.Options;

            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);

                    if (!response.Headers.Contains(AccessControlAllowOrigin))
                        response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

                    var accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                    if (accessControlRequestMethod != null)
                        response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);

                    var requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                    if (!string.IsNullOrEmpty(requestedHeaders))
                        response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);

                    return response;
                }

                var baseResponse = await base.SendAsync(request, cancellationToken);

                if (!baseResponse.Headers.Contains(AccessControlAllowOrigin))
                    baseResponse.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

                return baseResponse;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
