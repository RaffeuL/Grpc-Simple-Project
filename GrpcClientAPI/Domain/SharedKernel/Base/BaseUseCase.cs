namespace GrpcClientAPI.Domain.SharedKernel.Base
{
    public abstract class BaseUseCase
    {
        protected IServiceProvider _serviceProvider;
        
        public BaseUseCase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
