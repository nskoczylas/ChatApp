namespace ChatApp.Networking.Messaging;

public enum MessageType : byte
{
    HandshakePublicKey,
    HandshakeKey,
    EncryptedString
}