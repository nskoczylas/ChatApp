using ChatApp.Networking.Messaging;

namespace ChatApp.Networking.Security.Handshake;

public class AgentHandshake : KeyHandshake
{
    private Agent _context;
    private byte[] _hostPublicKey;

    public AgentHandshake(Agent agent)
    {
        _context = agent;
    }
    
    public override void StartHandshake()
    {
        SendPublicKey();
    }

    public override void OnPublicKey(byte[] payload)
    {
        _hostPublicKey = payload;
    }

    public override void OnEncryptedKey(byte[] payload)
    {
        var elements = MessageHelper.SplitPayloadFromIv(payload);
        var key = EncryptionPackage.Decrypt(GetDerivedKey(_hostPublicKey), elements[MessageComponent.IV], elements[MessageComponent.Payload]);
        EncryptionPackage.Instance.SetEncryptionKey(key);
    }

    protected override void SendPublicKey()
    {
        var msg = MessageHelper.CreateMessageFromTypeAndPayload(MessageType.HandshakePublicKey, 
            GetPublicKey());
        
        _context.Send(msg);
    }
}