namespace ChatApp.Networking.Messaging.Handling;

public abstract class MessageHandlingStrategy
{
    public abstract bool Accept(MessageType type);
    public abstract void Resolve(MessageType type, byte[] payload);
}