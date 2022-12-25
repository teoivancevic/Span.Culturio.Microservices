using System;
namespace Span.Culturio.Microservices.Core.Helpers
{
	public class CorrelationIdHeaderHandler : DelegatingHandler
	{
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("x-correlation-id"))
            {
                request.Headers.Add("x-correlation-id", Guid.NewGuid().ToString());
            }
           
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

