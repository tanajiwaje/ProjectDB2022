using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProjectDB2022.BL
{
    public class EncryptedUserId
    {
    

        public string Encrypt(string plainText)
        {
        string key = "YourSecretEncryptionKey123456774354556665554444333"; // Replace this with your encryption key
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (keyBytes.Length != 32) // 32 bytes = 256 bits
            {
                throw new ArgumentException("The key size is not valid for AES 256-bit encryption.");
            }

            using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;
            aesAlg.GenerateIV();

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            byte[] encryptedData;

            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encryptedData = msEncrypt.ToArray();
                }
            }

            string encryptedBase64 = Convert.ToBase64String(encryptedData);
            return encryptedBase64;
        }
    }

    public string Decrypt(string encryptedBase64)
    {
        string key = "MyKey"; // Replace this with your encryption key
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] encryptedData = Convert.FromBase64String(encryptedBase64);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;

            aesAlg.IV = new byte[aesAlg.BlockSize / 8]; // Set the IV to all zeroes for simplicity. In practice, use a unique IV.

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            string decryptedText;

            using (var msDecrypt = new System.IO.MemoryStream(encryptedData))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        decryptedText = srDecrypt.ReadToEnd();
                    }
                }
            }

            return decryptedText;
        }
    }

    public string GenerateEncryptedLink(int userId)
    {
        string encryptedUserId = Encrypt(userId.ToString());
            return encryptedUserId;
    }

    public int ExtractDecryptedUserId(string encryptedUserId)
    {
        string decryptedUserId = Decrypt(encryptedUserId);
        int userId;
        if (int.TryParse(decryptedUserId, out userId))
        {
            return userId;
        }
        else
        {
            // Handle invalid or tampered data
            return -1;
        }
    }

}
}