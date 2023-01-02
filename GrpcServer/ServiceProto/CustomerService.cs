using Grpc.Core;
using GrpcServer.Domain.UseCases;

namespace GrpcServer.ServiceProto
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly IServiceProvider _serviceProvider;
        
        public CustomerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task<BaseResponse> GetCustomerInfo(BaseRequest request, ServerCallContext context)
        {
            try
            {
                IUserCaseGetCustomerInfo useCase = _serviceProvider.GetRequiredService<IUserCaseGetCustomerInfo>();
                return await useCase.GetCustomerInfo(request);
                

            }
            catch (Exception e)
            {

                return GetErrorBase(e.Message);
            }
        }


        private BaseResponse GetErrorBase(string? message = "Problema de configuração")
        {
            return new BaseResponse();
        }
    }
}
