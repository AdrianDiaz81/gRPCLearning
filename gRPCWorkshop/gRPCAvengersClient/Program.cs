using Grpc.Net.Client;
using GrpcAvenger;

using var channel = GrpcChannel.ForAddress("https://localhost:7186/");
var client = new Avenger.AvengerClient(channel);
var empty = new Google.Protobuf.WellKnownTypes.Empty();
var reply = await client.GetAllAsync(empty);

foreach (var item in reply.Name)
{
    Console.WriteLine($"{item.Id}-{item.Name}-{item.Photo}");
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
