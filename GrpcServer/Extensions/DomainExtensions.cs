using GrpcServer.Domain.UseCases;

namespace GrpcServer.Extensions
{
    public static class DomainExtensions
    {
        public static void AddDomainExtensions(this IServiceCollection service)
        {
            #region UseCase
            service.AddScoped<IUserCaseGetCustomerInfo, UseCaseGetCustomerInfo>();
            #endregion
        }

    }
}
