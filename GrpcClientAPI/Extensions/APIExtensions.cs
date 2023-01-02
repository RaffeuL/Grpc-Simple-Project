namespace GrpcClientAPI.Extensions
{
    public static class APIExtensions
    {
        public static void RegistraAPI(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void RegistraAPI(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
        }
    }
}
