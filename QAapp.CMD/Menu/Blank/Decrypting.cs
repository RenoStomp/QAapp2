using System.Security.Cryptography;

namespace QAapp.CMD.Menu.Blank
{
    /// <summary>
    /// Don't mind about that 😶 Just pass by 😊
    /// </summary>
    internal static class Decrypting
    {
        #region VALUES

        static byte[] key = { 255, 117, 200, 75, 168, 60, 95, 6, 109, 80, 123, 141, 125, 247, 210, 6, 189, 45, 227, 241, 14, 3, 92, 201, 157, 166, 196, 196, 95, 129, 101, 143 };
        static byte[] iv = { 234, 251, 177, 125, 148, 20, 106, 62, 204, 104, 229, 178, 91, 21, 133, 169 };
        static byte[] encryptedText = { 36, 51, 112, 254, 240, 226, 95, 210, 0, 200, 15, 37, 88, 121, 46, 235, 152, 23, 5, 167, 139, 245, 231, 170, 66, 151, 211, 103, 233, 105, 67, 74 };

        #endregion
        /// <summary>
        /// DA NET TUT NICHEGO
        /// </summary>
        internal static string decryptedText = DecryptString(encryptedText, key, iv);

        /// <summary>
        /// shhhhhhhh teper eto nash sekret
        /// </summary>
        /// <param name="encryptedText">Chto-to strashnoe</param>
        /// <param name="key">Eshe strashnee</param>
        /// <param name="iv">BOOOOOOOOO!</param>
        /// <returns></returns>
        internal static string DecryptString(byte[] encryptedText, byte[] key, byte[] iv)
        {
            string decrypted;
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(encryptedText);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
                decrypted = sr.ReadToEnd();
            }
            return decrypted;
        }
    }
}
