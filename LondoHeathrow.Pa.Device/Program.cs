using Microsoft.AspNetCore.SignalR.Client;

namespace LondoHeathrow.Pa.Device;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Please enter a unique identifier for this Iot Device");
        var deviceIdentifier = Console.ReadLine();

        var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7154/pa-device-hub")
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
            await hubConnection.InvokeAsync("RecieveDeviceHeartbeat", deviceIdentifier);

            await Task.Delay(30000);
        }
    }
}

