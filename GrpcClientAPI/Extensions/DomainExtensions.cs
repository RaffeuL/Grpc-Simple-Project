using GrpcClientAPI.Domain.UseCases.GetCustomerInfo;

namespace GrpcClientAPI.Extensions
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainConfig(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseGetCustomerInfo, UseCaseGetCustomerInfo>();

            return services;
        }
    }
}
