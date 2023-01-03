using Grpc.Net.Client;
using GrpcClientAPI.Adapters.Grpc.Models;
using GrpcClientAPI.Domain.SharedKernel.InternalPorts;
using GrpcServer;
using Microsoft.Extensions.Options;

namespace GrpcClientAPI.Adapters.Grpc.Clients
{
    public class CustomerClient : GrpcClientPort
    {
        public readonly Customer.CustomerClient _client;
        protected GrpcChannel _customerChannel;
        private readonly IOptions<GrpcServiceSettings> _settings;

        public CustomerClient(IOptions<GrpcServiceSettings> settings)
        {
            _settings = settings;
            _customerChannel = GrpcChannel.ForAddress(settings.Value.GetService("CustomersData").Http);
            _client = new Customer.CustomerClient(_customerChannel);
        }

        public async Task<BaseResponse> GetCustomerInfo(BaseRequest request)
        {
            return await _client.GetCustomerInfoAsync(request);
        }
    }


}
