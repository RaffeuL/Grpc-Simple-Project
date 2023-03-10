using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;
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

        var custumerRequested = new BaseRequest { UserID =1 };
        var custumer = await custumerClient.GetCustomerInfoAsync(custumerRequested);

        Console.WriteLine($"{custumer.FirstName} {custumer.LastName}");
   
        Console.ReadLine();
    
    }

}
