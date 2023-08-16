using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

try {
    using var channel =  GrpcChannel.ForAddress("http://grpcserver:8080");
    var client = new Greeter.GreeterClient(channel);
    var reply = await client.SayHelloAsync(
        new HelloRequest { Name = "GreeterClient Bogdan" }
    );

    Console.WriteLine("Greeting: " + reply.Message);
    Console.WriteLine("Press any key to exit...");
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}



