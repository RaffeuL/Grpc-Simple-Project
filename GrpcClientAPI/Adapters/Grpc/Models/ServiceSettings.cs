namespace GrpcClientAPI.Adapters.Grpc.Models
{
    public record GrpcServiceSettings
    {
        public List<GrpcService> Services { get; set; }

        public void AddService(GrpcService service) => Services.Add(service);

        public GrpcService GetService(string name) => Services.Find(x => x.ServiceName == name);

    }


    public record GrpcService
    {
        public string ServiceName { get; set; }
        public string Http { get; set; }
        public string Https { get; set; }

        public GrpcService()
        {

        }

        GrpcService(string serviceName, string hosthttp, string hosthttps)
        {
            this.ServiceName = serviceName;
            this.Http = hosthttp;
            this.Https = hosthttps;
        }
    }
}
