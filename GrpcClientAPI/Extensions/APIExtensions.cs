using GrpcClientAPI.Adapters.Grpc.Extension;

namespace GrpcClientAPI.Extensions
{
    public static class APIExtensions
    {
        public static void RegistraAPI(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddGrpcService();
        }

        public static void RegistraAPI(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
        }
    }
}
