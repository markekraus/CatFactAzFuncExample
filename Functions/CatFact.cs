using System.Collections.Generic;
using System.Net;
using CatFactAzFunc.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace markekraus.Functions
{
    public class CatFact
    {
        private ICatFactService _service;
        public CatFact(ICatFactService service)
        {
            _service = service;
        }

        [Function("CatFact")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatFact");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(_service.GetFact());

            return response;
        }
    }
}
