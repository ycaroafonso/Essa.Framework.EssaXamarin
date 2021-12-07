namespace Essa.Framework.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;


    public static class Geral
    {
        public static string[] Meses()
        {
            return new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        }

        public static Dictionary<int, string> MesesComNumero()
        {
            return Meses().Select((item, index) => new { index = index + 1, item }).ToDictionary(c => c.index, d => d.item);
        }

        /// <summary>
        /// Lista de anos até o ano atual
        /// </summary>
        /// <param name="primeiro"></param>
        /// <returns></returns>
        public static IEnumerable<int> Anos(int primeiro)
        {
            for (int ano = primeiro; ano <= DateTime.Today.Year; ano++)
            {
                yield return ano;
            }
        }

        public static IEnumerable<int> Anos(int primeiro, int ate)
        {
            for (int i = primeiro; i <= ate; i++)
            {
                yield return i;
            }
        }


        public static Dictionary<string, string> SimNao()
        {
            return new Dictionary<string, string>
            {
                { "S", "Sim" },
                { "N", "Não" }
            };
        }

        public static Dictionary<bool, string> SimNaoBool()
        {
            return new Dictionary<bool, string>
            {
                { true, "Sim" },
                { false, "Não" }
            };
        }



        public static bool IsReleaseBuild
        {
            get
            {
#if DEBUG
                return false;
#else
    return true;
#endif
            }
        }



        /// <summary>
        /// Apenas com números e letras
        /// </summary>
        /// <param name="qtde"></param>
        /// <returns></returns>
        public static string GerarSenhaAleatoria(int qtde = 6, bool isletras = true, bool isnumeros = true)
        {
            string def = "";

            if (isletras)
                def += "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            if (isnumeros)
                def += "0123456789";

            Random rnd = new Random();

            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < qtde; i++)
                ret.Append(def.Substring(rnd.Next(def.Length), 1));

            return ret.ToString();
        }

        public static long DateDiff(DateInterval Interval, DateTime StartDate, DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }




        public static decimal Calcular(decimal valor1, string operador, decimal valor2)
        {
            switch (operador)
            {
                case "+":
                    return valor1 + valor2;
                case "-":
                    return valor1 - valor2;
                case "*":
                    return valor1 * valor2;
                case "/":
                    return valor1 / valor2;
            }
            throw new Exception("Operador inválido");
        }

    }

    public enum DateInterval
    {
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Quarter,
        Year
    }
}
