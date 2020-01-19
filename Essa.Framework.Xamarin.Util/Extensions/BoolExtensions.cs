namespace Essa.Framework.XamarinUtil.Extensions
{
    public static class BoolExtensions
    {
        public static bool IsNumber(this string valor)
        {
            int numero;
            return int.TryParse(valor, out numero);
        }

    }
}
