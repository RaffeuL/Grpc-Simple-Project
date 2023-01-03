using GrpcClientAPI.Adapters.Grpc.Clients;
using GrpcClientAPI.Adapters.Grpc.Models;
using GrpcClientAPI.Domain.SharedKernel.InternalPorts;

namespace GrpcClientAPI.Adapters.Grpc.Extension
{
    public static class GrpcExtension
    {
        public static IServiceCollection AddGrpcService(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.Fabrica.json")
                .Build();

            //services.AddSingleton(provider => configuration.GetSection("GrpcServiceConfiguration").Get<GrpcServiceSettings>());
            services.Configure<GrpcServiceSettings>(configuration.GetSection("GrpcServiceConfiguration"));
            services.AddScoped<GrpcClientPort, CustomerClient>();
            //services.Configure<GrpcService>(configuration.GetSection(nameof(GrpcServiceSettings)));

            return services;
        }
    }
}
