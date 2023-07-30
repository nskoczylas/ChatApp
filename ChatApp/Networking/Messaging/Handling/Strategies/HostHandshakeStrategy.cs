using ChatApp.Networking.Security.Handshake;

namespace ChatApp.Networking.Messaging.Handling.Strategies;

public class HostHandshakeStrategy : MessageHandlingStrategy
{
    private HostHandshake _handshake;

    public HostHandshakeStrategy(ConnectedAgent context)
    {
        _handshake = new HostHandshake(context);
    }
    
    public override bool Accept(MessageType type)
    {
        return type == MessageType.HandshakePublicKey;
    }

    public override void Resolve(MessageType type, byte[] payload)
    {
        _handshake.OnPublicKey(payload);
    }
}