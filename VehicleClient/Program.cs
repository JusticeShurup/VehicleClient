using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Net.Client;
using ProtosContract;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace VehicleClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, string> connections = new();
            using (StreamReader reader = new StreamReader("сonnectionSettings.json"))
            {
                string json = reader.ReadToEnd();
                JsonDocument document = JsonDocument.Parse(json);
                connections = JsonSerializer.Deserialize<Dictionary<string, string>>(document);
            };

            using var channelParking = GrpcChannel.ForAddress(connections["ParkingService"]);
            using var channelVehicle = GrpcChannel.ForAddress(connections["VehicleService"]);
            var parkingClient = new Parking.ParkingClient(channelParking);
            var vehiclesClient = new Vehicles.VehiclesClient(channelVehicle);

            /*
            var result = await parkingClient.CreateParkingAsync(new CreateParkingRq()
            {
                Address = "Колотушкино 123", 
                MaxFloor = 5,
                PlacesPerFloor = 5
            });
             */

            /*
            var result = await parkingClient.ParkVehicleAsync(new ParkVehicleRq()
            {
                ParkingId = "5f3597b8-2ecc-485a-896a-b7f4dd89df80",
                VehicleId = "19ed2944-2ab3-4d2b-b71e-1120edaf721d"
            });
            Console.WriteLine(result.ParkingPlaceId);
            */

            var result = await parkingClient.CreateParkingAsync(new CreateParkingRq()
            {
                Address = "Пушкина 2",
                MaxFloor = 5,
                PlacesPerFloor = 5
            });

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}