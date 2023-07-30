using System.Security.Cryptography;

namespace ChatApp.Networking.Security.Handshake;

public abstract class KeyHandshake
{
    private ECDiffieHellmanCng _localECDH;
    
    protected KeyHandshake()
    {
        _localECDH = new ECDiffieHellmanCng();
        _localECDH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
        _localECDH.HashAlgorithm = CngAlgorithm.Sha256;
    }

    public abstract void StartHandshake();

    public abstract void OnPublicKey(byte[] payload);

    public abstract void OnEncryptedKey(byte[] payload);

    protected abstract void SendPublicKey();

    protected byte[] GetPublicKey()
    {
        var publicKey = _localECDH.PublicKey;
        return publicKey.ExportSubjectPublicKeyInfo();
    }
    
    protected byte[] GetDerivedKey(byte[] remoteKeyBlob)
    {
        var remoteECDH = new ECDiffieHellmanCng();
        remoteECDH.ImportSubjectPublicKeyInfo(remoteKeyBlob, out _);
        return _localECDH.DeriveKeyMaterial(remoteECDH.PublicKey);
    }
}