namespace Essa.Framework.XamarinUtil.Extensions
{
    using System;
    using Util;


    public static class IntExtensions
    {
        public static bool Equals<T>(this int? valorOriginal, T valor) where T : struct, IConvertible
        {
            return valorOriginal == valor.ToInt32();
        }


        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static int IfZero(this int value, int ret)
        {
            return value == 0 ? ret : value;
        }

        public static int? IfZeroThenNull(this int value)
        {
            return value == 0 ? (int?)null : value;
        }



    }
}
