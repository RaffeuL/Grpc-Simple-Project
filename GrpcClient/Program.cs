using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

class Program 
{
    static async Task Main(string[] args)
    {

        var channel = GrpcChannel.ForAddress("https://localhost:7154");

        //var input = new HelloRequest { Name = "Rafeu"};
        //var client = new Greeter.GreeterClient(channel);

        //var reply = await client.SayHelloAsync(input);

        //Console.WriteLine(reply.Message);

        var custumerClient = new Customer.CustomerClient(channel);

        var custumerRequested = new CustomerLookupModel { UserID = 8 };
        var custumer = await custumerClient.GetCustomerInfoAsync(custumerRequested);

        Console.WriteLine($"{custumer.FirstName} {custumer.LastName}");

        Console.WriteLine();
        Console.WriteLine("New Costumers List");
        Console.WriteLine();

        using (var call = custumerClient.GetNewCustomers(new NewCustomerRequest()))
        {
            while(await call.ResponseStream.MoveNext())
            {
                var currentCustomer = call.ResponseStream.Current;
                Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} : {currentCustomer.EmailAddress}");

            }
        }
        Console.ReadLine();
    
    }

}
