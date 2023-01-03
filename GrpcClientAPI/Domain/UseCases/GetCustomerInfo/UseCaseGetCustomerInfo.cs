using GrpcClientAPI.Adapters.Grpc.Clients;
using GrpcClientAPI.Adapters.Grpc.Models;
using GrpcClientAPI.Domain.SharedKernel.Base;
using GrpcClientAPI.Domain.SharedKernel.InternalPorts;
using GrpcServer;

namespace GrpcClientAPI.Domain.UseCases.GetCustomerInfo
{
    public interface IUseCaseGetCustomerInfo
    {
        public Task<BaseResponse> USGetCostumerInfo(HttpRequest httpRequest, BaseRequest request);

    }
    public class UseCaseGetCustomerInfo : BaseUseCase, IUseCaseGetCustomerInfo
    {
        private readonly GrpcClientPort _service;

        public UseCaseGetCustomerInfo(IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            _service = serviceProvider.GetRequiredService<GrpcClientPort>();
            
        }

        public async Task<BaseResponse> USGetCostumerInfo(HttpRequest httpRequest, BaseRequest request)
        {
            var response = await _service.GetCustomerInfo(request);

            return response;
        }

    }
}
