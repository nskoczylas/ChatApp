using System.Security.Cryptography;
using ChatApp.Networking.Messaging;
using ChatApp.Networking.Security.Handshake;

namespace ChatApp.Networking.Security;

public class EncryptionPackage
{
    public static EncryptionPackage Instance
    {
        get
        {
            if (ReferenceEquals(_instance, null)) _instance = new EncryptionPackage();
            return _instance;
        }
    }
    private static EncryptionPackage? _instance;

    public byte[] EncryptionKey => _encryptionKey;
    private byte[] _encryptionKey;

    private EncryptionPackage()
    {
        _encryptionKey = GenerateEncryptionKey(256);
    }

    public void SetEncryptionKey(byte[] key)
    {
        _encryptionKey = key;
    }

    public byte[] GenerateEncryptionKey(int keySize)
    {
        var aes = Aes.Create();
        aes.KeySize = keySize;
        aes.GenerateKey();
        return aes.Key;
    }

    public static byte[] Encrypt(byte[] key, byte[] payload)
    {
        var aes = Aes.Create();
        aes.Key = key;

        var mStream = new MemoryStream();
        var cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        
        cStream.Write(payload, 0, payload.Length);
        cStream.Close();

        return MessageHelper.MergeTwoByteArrays(aes.IV, mStream.ToArray());
    }

    public static byte[] Decrypt(byte[] key, byte[] iv, byte[] payload)
    {
        var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        
        var mStream = new MemoryStream();
        var cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        
        cStream.Write(payload, 0, payload.Length);
        cStream.Close();

        return mStream.ToArray();
    }
}