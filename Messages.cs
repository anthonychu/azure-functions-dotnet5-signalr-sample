using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class Messages
    {
        [Function("Messages")]
        [SignalROutput(HubName = "chat")]
        public static async System.Threading.Tasks.Task<object> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Messages");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var message = await req.ReadFromJsonAsync<object>();

            return new {
                Target = "newMessage",
                Arguments = new object[] {
                    message
                }
            };
        }
    }
}
