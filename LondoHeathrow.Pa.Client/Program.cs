using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace LondoHeathrow.Pa.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Please enter a unique identifier for this Iot Device");
        var deviceIdentifier = Console.ReadLine();

        var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44341/pa-iot")
            .WithAutomaticReconnect()
            .Build();


        hubConnection.Reconnected += async (connectionId) =>
        {
            await hubConnection.InvokeAsync("RecieveDeviceReconnected", deviceIdentifier);
        };

        await hubConnection.StartAsync();

        await hubConnection.InvokeAsync("RecieveDeviceConnected", deviceIdentifier);


        while (true)
        {
            await hubConnection.InvokeAsync("RecieveHeartbeat", deviceIdentifier);

            await Task.Delay(30000);
        }
    }
}

