﻿using LondonHeathrow.Pa.Web.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace LondonHeathrow.Pa.Web.Hubs;

public class PaIotHub: Hub<IPaIotHub>
{
    private static Dictionary<string, string> _connectionMappings = new();

    public async Task RecieveDeviceHeartbeat(string deviceIdentifier)
    {
        await Clients.Group("Manager").RecieveDeviceHearbeat(deviceIdentifier);
    }

    public async Task RecieveDeviceConnected(string deviceIdentifier)
    {
        _connectionMappings.Add(Context.ConnectionId, deviceIdentifier);

        await Clients.Group("Manager").RecieveDeviceConnected(deviceIdentifier);
    }

    public async Task RecieveDeviceReconnected(string deviceIdentifier)
    {
        await Clients.Group("Manager").RecieveDeviceReconnected(deviceIdentifier);
    }

    public async Task RecieveClientConnected()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "Manager");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionMapping = _connectionMappings.FirstOrDefault(x => x.Key == Context.ConnectionId);

        if (connectionMapping.Equals(default))
        {
            return;
        }

        _connectionMappings.Remove(Context.ConnectionId);

        await Clients.Group("Manager").RecieveDeviceDisconnected(connectionMapping.Value);

    }
}

