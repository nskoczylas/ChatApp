using System.Diagnostics;
using ChatApp.Networking.Messaging;

namespace ChatApp.Networking.Security.Handshake;

public class HostHandshake : KeyHandshake
{
    private ConnectedAgent _context;

    public HostHandshake(ConnectedAgent agent)
    {
        _context = agent;
    }
    
    public override void StartHandshake()
    {
        throw new NotImplementedException();
    }

    public override void OnPublicKey(byte[] payload)
    {
        _context.AgentPublicKey = payload;
        SendPublicKey();
        SendKey();
    }

    public override void OnEncryptedKey(byte[] payload)
    {
        throw new NotImplementedException();
    }

    protected override void SendPublicKey()
    {
        var msg = MessageHelper.CreateMessageFromTypeAndPayload(MessageType.HandshakePublicKey, 
            GetPublicKey());
        
        _context.Send(msg);
    }

    private void SendKey()
    {
        var encryptionKey = GetDerivedKey(_context.AgentPublicKey);
        var encryptedPayload = EncryptionPackage.Encrypt(encryptionKey, EncryptionPackage.Instance.EncryptionKey);

        var msg = MessageHelper.CreateMessageFromTypeAndPayload(MessageType.HandshakeKey, encryptedPayload);
        _context.Send(msg);
    }
}