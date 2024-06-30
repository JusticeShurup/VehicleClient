using Grpc.Net.Client;
using ProtosContract;

namespace VehicleClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            using var channelParking = GrpcChannel.ForAddress("https://localhost:7271");
            var client = new Vehicles.VehiclesClient(channelParking);
            var result = client.DeleteVehicle(new DeleteVehicleRq() { Id = "d990a043-45fa-4ea5-b84a-9c62d637461e" });

            Console.Write(result.Success);
            Console.ReadLine();
        }
    }
}