using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class Negotiate
    {
        [Function("Negotiate")]
        public static HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            [SignalRConnectionInfoInput(HubName = "chat")] string connectionInfo,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Negotiate");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");

            response.WriteString(connectionInfo);

            return response;
        }
    }
}
