namespace LondonHeathrow.Pa.Web.Interfaces;

public interface IPaIotHub
{ 
    public Task RecieveDeviceHearbeat(string deviceIdentifier);
    public Task RecieveDeviceConnected(string deviceIdentifier);
    public Task RecieveDeviceReconnected(string deviceIdentifier);
    public Task RecieveDeviceDisconnected(string deviceIdentifier);
}