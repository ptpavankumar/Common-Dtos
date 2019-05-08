namespace ApiUtility.Crypto
{
    public interface IEncryptionUtility
    {
        string Decrypt(string cipherText);
        string Encrypt(string cipherText);
    }
}