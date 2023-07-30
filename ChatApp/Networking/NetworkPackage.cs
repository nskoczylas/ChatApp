using ChatApp.Networking.Messaging;
using LiteNetwork;
using LiteNetwork.Client;
using LiteNetwork.Server;

namespace ChatApp.Networking;

public class NetworkPackage
{
    public static NetworkPackage Instance
    {
        get
        {
            if (ReferenceEquals(_instance, null)) _instance = new NetworkPackage();
            return _instance;
        }
    }
    private static NetworkPackage? _instance;

    public Action<string> OnMessage;
    
    private Host _host;
    private Agent _agent;

    public async Task StartHost(string ip, int port)
    {
        var config = new LiteServerOptions()
        {
            ReceiveStrategy = ReceiveStrategyType.Queued,
            Host = ip,
            Port = port
        };

        _host = new Host(config);
        await _host.StartAsync();
    }

    public async Task StartAgent(string ip, int port)
    {
        var config = new LiteClientOptions()
        {
            ReceiveStrategy = ReceiveStrategyType.Queued,
            Host = ip,
            Port = port
        };

        _agent = new Agent(config);
        await _agent.ConnectAsync();
    }

    public void SendMessage(string input)
    {
        var msg = MessageHelper.CreateEncryptedStringMessage(input);
        if (ReferenceEquals(_agent, null))
        {
            _host.SendToAll(msg);
            OnMessage?.Invoke(input);
        }
        else _agent.Send(msg);
    }
}