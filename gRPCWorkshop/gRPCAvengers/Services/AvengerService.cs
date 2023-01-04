using Grpc.Core;
using GrpcAvenger;

namespace gRPCAvengers.Services
{
    public class AvengerService : Avenger.AvengerBase
    {
        private readonly ILogger<AvengerService> _logger;
        private readonly IList<AvengerCharacter> _avengersCollection;

        public AvengerService(ILogger<AvengerService> logger)
        {
            this._logger=logger;
            _avengersCollection = new List<AvengerCharacter>()
                {
                    new AvengerCharacter { Id ="1", Name="Hulk", Photo=""},
                    new AvengerCharacter { Id ="2", Name="Capitan Americana", Photo=""},
                    new AvengerCharacter { Id ="3", Name="Iron Man", Photo=""}
                 };
        }

        public override Task<GetAllReply> GetAll(Google.Protobuf.WellKnownTypes.Empty request,ServerCallContext context)
        {
            _logger.LogInformation("Init GetAll");
            var response = new GetAllReply();                        
            response.Name.AddRange(_avengersCollection);
            return Task.FromResult(response);
        }

        public override Task<GetReply> Get (IdAvenger request, ServerCallContext context)
        {
            _logger.LogInformation("Init GetAll");
            var response = new GetReply
            {
                Message= _avengersCollection.Where(x => x.Id.Equals(request.Name)).FirstOrDefault()
            };
            return Task.FromResult(response);
        }
    }
}
