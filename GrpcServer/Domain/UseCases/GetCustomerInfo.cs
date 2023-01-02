using GrpcServer.Domain.SharedKernel.BaseUseCase;

namespace GrpcServer.Domain.UseCases
{
    public interface IUserCaseGetCustomerInfo
    {
        Task<BaseResponse> GetCustomerInfo(BaseRequest request);
    }

    public class UseCaseGetCustomerInfo : BaseUseCase, IUserCaseGetCustomerInfo
    {
        public UseCaseGetCustomerInfo(IServiceProvider serviceProvider) : base(serviceProvider) 
        { 

        }
   
        public async Task<BaseResponse> GetCustomerInfo(BaseRequest request)
        {

            BaseResponse output = new BaseResponse();
            switch (request.UserID)
            {
                case 0:
                    output.FirstName = "Rafael";
                    output.LastName = "Lisboa";
                    output.EmailAddress = "rafel@email.com";
                    output.Age = 23;
                    output.IsAlive = true;
                    break;
                case 1:
                    output.FirstName = "Iury";
                    output.LastName = "Glabson";
                    output.EmailAddress = "iury@email.com";
                    output.Age = 23;
                    output.IsAlive = false;
                    break;
                case 2:
                    output.FirstName = "João";
                    output.LastName = "Dantas";
                    output.EmailAddress = "jao@email.com";
                    output.Age = 23;
                    output.IsAlive = true;
                    break;
                default:
                    output.FirstName = "No One";
                    output.LastName = "da Silva";
                    break;
            }

            return output;
        }
    }
}
