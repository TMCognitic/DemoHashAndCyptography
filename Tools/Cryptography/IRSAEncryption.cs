namespace Tools.Cryptography
{
    public interface IRSAEncryption
    {
        byte[] BinaryKeys { get;  }
        int KeySize { get; }
        byte[] PublicBinaryKey { get; }
        string PublicXmlKey { get; }
        string XmlKeys { get; }

        string Decrypt(byte[] value);
        byte[] Encrypt(string value);
        void ImportBinaryKeys(byte[] keys);
        void ImportXmlKeys(string xml);
    }
}