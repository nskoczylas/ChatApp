using System.Text;
using ChatApp.Networking.Security;

namespace ChatApp.Networking.Messaging;

public static class MessageHelper
{
    public static byte[] CreateMessageFromTypeAndPayload(MessageType type, byte[] payload)
    {
        var typeAsByte = GetMessageTypeAsByte(type);
        var msg = MergeByteWithByteArray(typeAsByte, payload);

        return msg;
    }

    public static byte[] CreateEncryptedStringMessage(string input)
    {
        var typeAsByte = GetMessageTypeAsByte(MessageType.EncryptedString);
        
        var payload = Encoding.UTF8.GetBytes(input);
        var encryptedPayload = EncryptionPackage.Encrypt(EncryptionPackage.Instance.EncryptionKey, payload);

        var msg = MergeByteWithByteArray(typeAsByte, encryptedPayload);
        return msg;
    }
    
    public static Dictionary<MessageComponent, byte[]> SplitPayloadFromType(byte[] msg)
    {
        var elements = new Dictionary<MessageComponent, byte[]>();

        var extractedTypeAsByte = new byte[1];
        var extractedPayload = new byte[msg.Length - 1];

        extractedTypeAsByte[0] = msg[0];
        Buffer.BlockCopy(msg, 1, extractedPayload, 0, msg.Length - 1);
        
        elements.Add(MessageComponent.MessageType, extractedTypeAsByte);
        elements.Add(MessageComponent.Payload, extractedPayload);
        return elements;
    }

    public static Dictionary<MessageComponent, byte[]> SplitPayloadFromIv(byte[] msg, int ivLenght = 16)
    {
        var elements = new Dictionary<MessageComponent, byte[]>();

        var extractedIV = new byte[ivLenght];
        var extractedPayload = new byte[msg.Length - ivLenght];
        
        Buffer.BlockCopy(msg, 0, extractedIV, 0, ivLenght);
        Buffer.BlockCopy(msg, ivLenght, extractedPayload, 0, msg.Length - ivLenght);
        
        elements.Add(MessageComponent.IV, extractedIV);
        elements.Add(MessageComponent.Payload, extractedPayload);
        return elements;
    }
    
    public static byte[] MergeByteWithByteArray(byte singleByte, byte[] array)
    {
        var mergedArray = new byte[array.Length + 1];
        mergedArray[0] = singleByte;
        Buffer.BlockCopy(array, 0, mergedArray, 1, array.Length);

        return mergedArray;
    }

    public static byte[] MergeTwoByteArrays(byte[] firstArray, byte[] secondArray)
    {
        var firstLength = firstArray.Length;
        var secondLength = secondArray.Length;
        
        var mergedArray = new byte[firstLength + secondLength];
        Buffer.BlockCopy(firstArray, 0, mergedArray, 0, firstLength);
        Buffer.BlockCopy(secondArray, 0, mergedArray, firstLength, secondLength);

        return mergedArray;
    }

    public static byte GetMessageTypeAsByte(MessageType type) => (byte)type;

    public static MessageType GetMessageTypeFromByte(byte type) => (MessageType)type;
}