using Grpc.Net.Client;
using GrpcClientAPI.Domain.SharedKernel.BaseUseCase;
using GrpcServer;

namespace GrpcClientAPI.Domain.UseCases.GetCostumerInfo
{
    public interface IUseCaseGetCustomerInfo
    {
        public Task<BaseResponse> USGetCostumerInfo(HttpRequest httpRequest, BaseRequest request);

    }
    public class UseCaseGetCustomerInfo : BaseUseCase, IUseCaseGetCustomerInfo
    {
        private GrpcChannel _channel { get; set; }
        private Customer.CustomerClient _customerClient { get; set; }

        public UseCaseGetCustomerInfo(IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            _channel = GrpcChannel.ForAddress("https://localhost:7154");
            _customerClient = new Customer.CustomerClient(_channel);
        }

        public async Task<BaseResponse> USGetCostumerInfo(HttpRequest httpRequest, BaseRequest request)
        {
            var customer = await _customerClient.GetCustomerInfoAsync(request);
            return customer;
        }

    }
}
