using System.Diagnostics;
using ChatApp.Networking.Messaging.Handling;
using ChatApp.Networking.Messaging.Handling.Strategies;
using LiteNetwork.Server;

namespace ChatApp.Networking;

public class ConnectedAgent : LiteServerUser
{
    public byte[] AgentPublicKey;
    private MessageHandler _messageHandler = new MessageHandler();
    
    public override Task HandleMessageAsync(byte[] packetBuffer)
    {
        _messageHandler.OnMessage(packetBuffer);
        return base.HandleMessageAsync(packetBuffer);
    }

    protected override void OnConnected()
    {
        Debug.WriteLine("[ConnectedAgent] New client connected.");
        _messageHandler.AddStrategy(new HostHandshakeStrategy(this));
        _messageHandler.AddStrategy(new HostEncryptedStringStrategy());
        base.OnConnected();
    }
}