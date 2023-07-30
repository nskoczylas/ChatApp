using System.Text;
using ChatApp.Networking.Security;

namespace ChatApp.Networking.Messaging.Handling.Strategies;

public class HostEncryptedStringStrategy : MessageHandlingStrategy
{
    public override bool Accept(MessageType type)
    {
        return type == MessageType.EncryptedString;
    }

    public override void Resolve(MessageType type, byte[] payload)
    {
        var elements = MessageHelper.SplitPayloadFromIv(payload);
        var decryptedPayload = EncryptionPackage.Decrypt(EncryptionPackage.Instance.EncryptionKey,
            elements[MessageComponent.IV],
            elements[MessageComponent.Payload]);

        var message = Encoding.UTF8.GetString(decryptedPayload);
        NetworkPackage.Instance.SendMessage(message);
    }
}