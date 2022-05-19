using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;    

namespace ECDiffieHelmanCng
{
    class Alice
    {
        public static byte[] byteAlicePublicKey;

        public static void Main(string[] args)
        {

            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {


                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                byteAlicePublicKey = alice.PublicKey.ToByteArray();

                Bob bob = new Bob();
                CngKey bobkey = CngKey.Import(bob.byteBobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                byte[] aliceKey = alice.DeriveKeyMaterial(bobkey);
                byte[] encrypedMessage = null;
                byte[] iv = null;

                Send(aliceKey, "Secret message", out encrypedMessage, out iv);
                bob.Receive(encrypedMessage, iv);
            }

        }

        private static void Send(byte[] key, string secretMessage, out byte[] encryptedMessage, out byte[] iv)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                iv = aes.IV;

                //Encrypt the message

                using (MemoryStream ciphertext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {

                        byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                        cs.Close();
                        encryptedMessage = ciphertext.ToArray();
                    }
                }
            }
        }

        public class Bob
        {


            public byte[] byteBobPublicKey;
            private byte[] bobKey;
            public Bob()
            {
                using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
                {
                    bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                    bob.HashAlgorithm = CngAlgorithm.Sha256;
                    byteBobPublicKey = bob.PublicKey.ToByteArray();
                    bobKey = bob.DeriveKeyMaterial(CngKey.Import(Alice.byteAlicePublicKey, CngKeyBlobFormat.EccFullPublicBlob));
                }
            }

            public void Receive(byte[] encryptedMessage, byte[] iv)
            {

                using (Aes aes = new AesCryptoServiceProvider())
                {

                    aes.Key = bobKey;
                    aes.IV = iv;

                    //Decrypt the message
                    using (MemoryStream plaintex = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(plaintex, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {

                            cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                            cs.Close();

                            string message = Encoding.UTF8.GetString(plaintex.ToArray());
                            Console.WriteLine(message);
                        }
                    }
                }
            }
        }



   


        


       
    }
}
