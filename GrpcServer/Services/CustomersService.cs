using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger) {
            _logger = logger;
        }


        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            switch (request.UserID)
            {
                case 0: 
                    output.FirstName = "Rafael";
                    output.LastName = "Lisboa";
                break;
                case 1:
                    output.FirstName = "Jane";
                    output.LastName = "Foster";
                break;
                case 2:
                    output.FirstName = "Greg";
                    output.LastName = "Greg";
                break;
                default:
                    output.FirstName = "No One";
                    output.LastName = "da Silva";
                break;
            }

            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> custumers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Tim",
                    LastName = "Burton",
                    EmailAddress = "tim@email.com",
                    Age = 64,
                    IsAlive = true,
                },
                new CustomerModel
                {
                    FirstName = "Iury",
                    LastName = "Glabson",
                    EmailAddress = "iury@email.com",
                    Age = 23,
                    IsAlive = true,
                },
                new CustomerModel
                {
                    FirstName = "Jão",
                    LastName = "Dantas",
                    EmailAddress = "jao@email.com",
                    Age = 5,
                    IsAlive = false,
                },

            };

            foreach (var cust in custumers)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(cust);
            }
        }
    }
}
