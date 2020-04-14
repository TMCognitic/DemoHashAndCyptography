using System;
using System.IO;
using Tools.Cryptography;

namespace KeysGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAEncryption encryption = new RSAEncryption(2048);
            File.WriteAllBytes("keys.bin", encryption.BinaryKeys);
        }
    }
}
