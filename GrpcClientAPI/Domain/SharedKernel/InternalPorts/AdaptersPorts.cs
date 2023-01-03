using GrpcServer;

namespace GrpcClientAPI.Domain.SharedKernel.InternalPorts
{
    public interface GrpcClientPort
    {
        Task<BaseResponse> GetCustomerInfo(BaseRequest request);
    }
}
