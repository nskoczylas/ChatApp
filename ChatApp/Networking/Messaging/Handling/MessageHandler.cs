namespace ChatApp.Networking.Messaging.Handling;

public class MessageHandler
{
    private List<MessageHandlingStrategy> _strategies = new List<MessageHandlingStrategy>();

    public void AddStrategy(MessageHandlingStrategy strategy)
    {
        _strategies.Add(strategy);
    }

    public void OnMessage(byte[] message)
    {
        var elements = MessageHelper.SplitPayloadFromType(message);
        var type = MessageHelper.GetMessageTypeFromByte(elements[MessageComponent.MessageType][0]);
        var payload = elements[MessageComponent.Payload];

        foreach (var strategy in _strategies)
        {
            if (strategy.Accept(type))
            {
                strategy.Resolve(type, payload);
                return;
            }
        }
    }
}