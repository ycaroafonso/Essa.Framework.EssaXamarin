using System;
using System.IO;

namespace Essa.Framework.XamarinUtil.Extensions
{
    public static class ByteExtensions
    {

        ///// <summary>
        ///// Converte uma byte[] para Image
        ///// </summary>
        ///// <param name="byteArrayIn">The byte array in.</param>
        ///// <returns></returns>
        //public static System.Drawing.Image ToImagem(this byte[] byteArrayIn)
        //{
        //    using (MemoryStream ms = new MemoryStream(byteArrayIn))
        //        return System.Drawing.Image.FromStream(ms);
        //}


        public static string ToBase64(this byte[] file)
        {
            return Convert.ToBase64String(file);
        }

        public static string ToConteudoString(this byte[] file)
        {
            return System.Text.Encoding.UTF8.GetString(file);
        }

        public static Stream ToStream(this byte[] file)
        {
            MemoryStream theMemStream = new MemoryStream();

            theMemStream.Write(file, 0, file.Length);

            return theMemStream;
        }

    }
}
