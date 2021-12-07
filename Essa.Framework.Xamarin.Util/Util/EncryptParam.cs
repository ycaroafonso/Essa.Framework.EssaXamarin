namespace Essa.Framework.Util.Util
{
    using System;
    using System.Text;
    
    public static class EncryptParam
    {
        public static string Encrypt(string stringToEncrypt)
        {
            try
            {
                Byte[] b = Encoding.UTF8.GetBytes(stringToEncrypt);
                return Convert.ToBase64String(b);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string stringToDecrypt)
        {
            try
            {
                Byte[] b = Convert.FromBase64String(stringToDecrypt);
                return Encoding.UTF8.GetString(b);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
