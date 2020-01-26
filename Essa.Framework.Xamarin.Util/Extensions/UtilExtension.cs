namespace Essa.Framework.Util.Extensions
{
    using Extensions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;


    public static class UtilExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static int ToInt32(this object valor)
        {
            return Convert.ToInt32(valor);
        }


        public static decimal IfNegative(this decimal value, Func<decimal, decimal> actionReturn)
        {
            return value < 0 ? actionReturn(value) : value;
        }



        public static T IfNull<T>(this T value, T ret)
        {
            return value == null ? ret : value;
        }

        public static Ret IfNull<T, Ret>(this T value, Ret valorSeNull, Func<T, Ret> valorfalse)
        {
            if (value == null)
                return valorSeNull;
            else
                return valorfalse(value);
        }



        #region IfOnly

        public static T IfOnly<T>(this T value, bool condit, T ret)
        {
            return condit ? ret : value;
        }
        public static T IfOnly<T>(this T value, Func<T, bool> condit, T ret)
        {
            return condit(value) ? ret : value;
        }

        /// <summary>
        /// Compara as key de um dictionary e retorna value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static T IfOnly<T>(this T value, Dictionary<T, T> ret)
        {
            if (ret.ContainsKey(value))
                return ret[value];

            return value;
        }


        /// <summary>
        /// Compara as key de um dictionary e retorna value, se não existir, retorna o parâmetro valorelse;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="value"></param>
        /// <param name="ret"></param>
        /// <param name="valorelse"></param>
        /// <returns></returns>
        public static V IfOnly<T, V>(this T value, Dictionary<T, V> ret, V valorelse)
        {
            if (ret.ContainsKey(value))
                return ret[value];

            return valorelse;
        }

        #endregion



        /// <summary>
        /// IfGreaterLessOrZero
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="seMaior"></param>
        /// <param name="seMenor"></param>
        /// <param name="seZero"></param>
        /// <returns></returns>
        public static string MaiorMenorOuZero(this decimal valor, string seMaior, string seMenor, string seZero)
        {
            switch (valor.CompareTo(0))
            {
                case -1:
                    return seMenor;
                case 0:
                    return seZero;
                default:
                    return seMaior;
            }
        }

        public static string ToMesExtenso(this int mes)
        {
            return Geral.Meses()[mes - 1];
        }

        public static byte[] ToByteArray(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


        public static Dictionary<int, T> ToDictionary<T>(this T[] lista)
        {
            return lista.Select((item, index) => new { index, item }).ToDictionary(c => c.index, d => d.item);
        }


        public static string FormataCpf(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return valor;
            return string.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(valor));
        }

        public static string FormataCnpj(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return valor;
            return string.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(valor));
        }

        public static string FormataCpfCnpj(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            if (valor.Length == 11)
                return valor.FormataCpf();
            else
                return valor.FormataCnpj();
        }

        public static String DateToStr(this DateTime valor)
        {
            return Convert.ToDateTime(valor).ToString("dd/MM/yyyy");
        }

        public static String DateToStr(this DateTime? valor)
        {
            if (valor == null)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToDateTime(valor).ToString("dd/MM/yyyy");
            }
        }

        public static T IfContainsOnlyOne<T>(this IEnumerable<T> lista)
        {
            if (lista.Count() == 1)
                return lista.Single();
            return default(T);
        }

        public static T[] Remove<T>(this T[] arr, T itemRemover)
        {
            var lista = arr.ToList();
            lista.Remove(itemRemover);
            return lista.ToArray();
        }
    }
}