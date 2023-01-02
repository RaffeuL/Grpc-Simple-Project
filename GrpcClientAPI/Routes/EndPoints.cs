using GrpcClientAPI.Domain.UseCases.GetCostumerInfo;
using GrpcServer;

namespace GrpcClientAPI.Routes
{
    public static class EndPoints
    {

        public static void AddEndPoints(this WebApplication app, IServiceProvider serviceProvider)
        {
            app.UseRouting();

            app.MapPost("Costumer/Info", (HttpRequest httpRequest, BaseRequest request) => 
            (serviceProvider.GetService(typeof(IUseCaseGetCustomerInfo)) as IUseCaseGetCustomerInfo).USGetCostumerInfo(httpRequest, request));
        }
    }
}
