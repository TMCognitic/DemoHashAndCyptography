using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace DemoCryptage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Symmetric encryption...");
            //SymmetricEncryption();
            
            Console.WriteLine(Environment.NewLine + "Asymmetric encryption...");
            AsymmetricEncryption();
        }

        #region How To Crypt and Decrypt with a Symmetric Algorithm (Clé unique pour le cryptage et le décryptage)
        private static void SymmetricEncryption()
        {
            byte[] vector;
            byte[] key;

            //SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();
            //symmetricAlgorithm.GenerateIV();
            //symmetricAlgorithm.GenerateKey();

            //key = symmetricAlgorithm.Key;
            //vector = symmetricAlgorithm.IV;

            //File.WriteAllBytes("vector.bin", vector);
            //File.WriteAllBytes("key.bin", key);

            byte[] cryptedValue = SymmetricCrypt("test1234=");
            string base64 = Convert.ToBase64String(cryptedValue);
            Console.WriteLine(base64.Length);
            Console.WriteLine(base64);

            string value = SymmetricDecrypt(cryptedValue);
            Console.WriteLine(value);
        }
        private static byte[] SymmetricCrypt(string value)
        {
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();
            symmetricAlgorithm.Key = File.ReadAllBytes("key.bin");
            symmetricAlgorithm.IV = File.ReadAllBytes("vector.bin");

            ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor();

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(value);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
        private static string SymmetricDecrypt(byte[] cryptedValue)
        {
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();
            symmetricAlgorithm.Key = File.ReadAllBytes("key.bin");
            symmetricAlgorithm.IV = File.ReadAllBytes("vector.bin");

            ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor();

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cryptedValue))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        #endregion

        #region How To Crypt and Decrypt with a Asymmetric Algorithm (Clés publique et privée)
        private static void AsymmetricEncryption()
        {
            string passwd = "test1234=";

            int keySize = 2048;
            Console.WriteLine($"Longueur maximale du texte : {((keySize / 8) - 42) / 2}");

            RSACryptoServiceProvider asymmetricAlgorithm = new RSACryptoServiceProvider(keySize);

            byte[] keys = asymmetricAlgorithm.ExportCspBlob(true);
            byte[] publicKey = asymmetricAlgorithm.ExportCspBlob(false);

            File.WriteAllBytes("keys.bin", keys);
            File.WriteAllBytes("publicKey.bin", publicKey);

            byte[] cryptedValue = AsymmetricCrypt(passwd);
            string base64 = Convert.ToBase64String(cryptedValue);
            Console.WriteLine(base64.Length);
            Console.WriteLine(base64);

            string value = AsymmetricDecrypt(cryptedValue);
            Console.WriteLine(value);

        }
        private static byte[] AsymmetricCrypt(string value)
        {
            byte[] publicKey = File.ReadAllBytes("publicKey.bin");

            RSACryptoServiceProvider asymmetricAlgorithm = new RSACryptoServiceProvider();
            asymmetricAlgorithm.ImportCspBlob(publicKey);

            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            return asymmetricAlgorithm.Encrypt(unicodeEncoding.GetBytes(value), true);
        }
        private static string AsymmetricDecrypt(byte[] cryptedValue)
        {
            byte[] keys = File.ReadAllBytes("keys.bin");

            RSACryptoServiceProvider asymmetricAlgorithm = new RSACryptoServiceProvider();
            asymmetricAlgorithm.ImportCspBlob(keys);

            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] binaryValue = asymmetricAlgorithm.Decrypt(cryptedValue, true);
            return unicodeEncoding.GetString(binaryValue);
        }
        #endregion        
    }
}
