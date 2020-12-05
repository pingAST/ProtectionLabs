using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionLabs
{
    class DiffieHellman : IDisposable
    {
        #region Private Fields
        /* 
        Глосарий
        AES ( Advanced Encryption Standard ), представляет собой алгоритм с симметричным ключом, это означает, 
        что один и тот же ключ используется как для шифрования, так и для дешифрования данных.
        
        CNG ( Cryptography Next Generation ) - платформа для разработки криптографии, 
        которая позволяет разработчикам создавать, обновлять и использовать 
        собственные алгоритмы криптографии в приложениях, связанных с криптографией
        
        Диффи-Хеллмана - метод безопасного обмена криптографическими ключами 
        по общедоступному каналу, который был одним из первых протоколов 
        с открытым ключом, первоначально концептуализированных Ральфом Мерклом и 
        названных в честь Уитфилда  Диффи  и Мартина  Хеллмана . 
        
        IV (I- вектор инициализации ) - произвольное число, которое может использоваться 
        вместе с секретным ключом для шифрования данных. 
        Этот номер, также называемый одноразовым номером, используется только один раз 
        в любом сеансе. (Мы будем использовать IV и открытый ключ другой стороны 
        для расшифровки секретного сообщения.)

        */

        private Aes aes = null;
        private ECDiffieHellmanCng diffieHellman = null;

        private readonly byte[] publicKey;
        #endregion

        #region Constructor
        public DiffieHellman()
        {
            this.aes = new AesCryptoServiceProvider();

            this.diffieHellman = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };

            // Это открытый ключ, который мы отправим другой стороне
            this.publicKey = this.diffieHellman.PublicKey.ToByteArray();
        }
        #endregion

        #region Public Properties
        public byte[] PublicKey
        {
            get
            {
                return this.publicKey;
            }
        }

        public byte[] IV
        {
            get
            {
                return this.aes.IV;
            }
        }

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        #endregion

        #region Public Methods
        public byte[] Encrypt(byte[] publicKey, string secretMessage)
        {
            byte[] encryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key); /// «Общий секрет»

            this.aes.Key = derivedKey;

            using (var cipherText = new MemoryStream())
            {
                using (var encryptor = this.aes.CreateEncryptor())
                {
                    using (var cryptoStream = new CryptoStream(cipherText, encryptor, CryptoStreamMode.Write))
                    {
                       
                        byte[] ciphertextMessage = ByteConverter.GetBytes(secretMessage);
                        cryptoStream.Write(ciphertextMessage, 0, ciphertextMessage.Length);
                    }
                }

                encryptedMessage = cipherText.ToArray();
            }

            return encryptedMessage;
        }

        public string Decrypt(byte[] publicKey, byte[] encryptedMessage, byte[] iv)
        {
            string decryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key);

            this.aes.Key = derivedKey;
            this.aes.IV = iv;

            using (var plainText = new MemoryStream())
            {
                using (var decryptor = this.aes.CreateDecryptor())
                {
                    using (var cryptoStream = new CryptoStream(plainText, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
                    }
                }

                decryptedMessage = ByteConverter.GetString(plainText.ToArray());
            }

            return decryptedMessage;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.aes != null)
                    this.aes.Dispose();

                if (this.diffieHellman != null)
                    this.diffieHellman.Dispose();
            }
        }
        #endregion

    }
}
