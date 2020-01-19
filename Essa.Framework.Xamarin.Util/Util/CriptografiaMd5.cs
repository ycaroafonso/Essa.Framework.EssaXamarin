namespace Essa.Framework.XamarinUtil.Util
{
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    using System.Text;


    public class CriptografiaMd5
    {
        private byte[] _texto;

        private string Encrypt()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                _texto = md5Hash.ComputeHash(_texto);

                return string.Join("", _texto.Select(c => c.ToString("x2")));
            }
        }

        public string Encrypt(byte[] texto)
        {
            _texto = texto;
            return Encrypt();
        }

        public string Encrypt(string texto)
        {
            _texto = Encoding.UTF8.GetBytes(texto);
            return Encrypt();
        }

        public string Encrypt(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                _texto = ms.ToArray();
            }

            return Encrypt();
        }
    }
}
