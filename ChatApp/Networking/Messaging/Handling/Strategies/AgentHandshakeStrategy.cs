using ChatApp.Networking.Security.Handshake;

namespace ChatApp.Networking.Messaging.Handling.Strategies;

public class AgentHandshakeStrategy : MessageHandlingStrategy
{
    private Agent _context;
    public AgentHandshakeStrategy(Agent context)
    {
        _context = context;
    }
    
    public override bool Accept(MessageType type)
    {
        if (type == MessageType.HandshakePublicKey || type == MessageType.HandshakeKey) return true;
        return false;
    }

    public override void Resolve(MessageType type, byte[] payload)
    {
        if (type == MessageType.HandshakePublicKey) _context.Handshake.OnPublicKey(payload);
        else _context.Handshake.OnEncryptedKey(payload);
    }
}