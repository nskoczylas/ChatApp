using System.Diagnostics;
using ChatApp.Networking.Messaging.Handling;
using ChatApp.Networking.Messaging.Handling.Strategies;
using ChatApp.Networking.Security.Handshake;
using LiteNetwork.Client;

namespace ChatApp.Networking;

public class Agent : LiteClient
{
    public AgentHandshake Handshake => _handshake;
    
    private MessageHandler _messageHandler = new MessageHandler();
    private AgentHandshake _handshake;
    public Agent(LiteClientOptions options, IServiceProvider? serviceProvider = null) : base(options, serviceProvider)
    {
        _handshake = new AgentHandshake(this);
        _messageHandler.AddStrategy(new AgentHandshakeStrategy(this));
        _messageHandler.AddStrategy(new AgentEncryptedStringStrategy());
    }

    public override Task HandleMessageAsync(byte[] packetBuffer)
    {
        _messageHandler.OnMessage(packetBuffer);
        return base.HandleMessageAsync(packetBuffer);
    }

    protected override void OnConnected()
    {
        _handshake.StartHandshake();
        base.OnConnected();
    }
}