using System.Text.Json;
using Domain.Exceptions;
using Shared.ErrorModel;

namespace E_Commerce.web.CustomerMiddlewares
{
    public class CustomerExceptionMiddlewares
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomerExceptionMiddlewares> logger;

        public CustomerExceptionMiddlewares(RequestDelegate Next , ILogger<CustomerExceptionMiddlewares> logger)
        {
            next = Next;
            this.logger = logger;
        }

        public async Task Invoke (HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //logger
                logger.LogError(ex, "SomeTing Wrong");

                //response
                //1. Set StatusCode For Response
                httpContext.Response.StatusCode = ex switch
                {
                    NotFoundExceptions => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                    

                //.2 Set Content Type For Response
                httpContext.Response.ContentType = "application/json";

                //3. Response Object
                var Response = new ErrorToReturn()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = ex.Message
                };

                //4. Return Object as json
                var ResponseToReturn = JsonSerializer.Serialize(Response);
                await httpContext.Response.WriteAsync(ResponseToReturn);

            }
        }
    }
}
