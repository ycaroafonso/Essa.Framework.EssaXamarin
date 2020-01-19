namespace Essa.Framework.XamarinUtil.Extensions
{
    using System;


    public static class DateTimeExtension
    {
        public static DateTime ToFirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime ToLastDayOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1)
                .AddMonths(1)
                .AddDays(-1);
        }


        public static DateTime ToFirstDayOfWeek(this DateTime data)
        {
            return data.AddDays((int)data.DayOfWeek * -1);
        }


        public static DateTime ToLastDayOfWeek(this DateTime data)
        {
            return data.AddDays(6 - (int)data.DayOfWeek);
        }


        public static DateTime SetYear(this DateTime date, int ano)
        {
            return date.AddYears(ano - date.Year);
        }


        public static string TempoPassado(this DateTime date)
        {
            return (DateTime.Now - date).TempoPassado();
        }

        public static string TempoPassado(this DateTime date, int qtdeMaxDias)
        {
            var x = (DateTime.Now - date);

            if (x.TotalDays > qtdeMaxDias)
                return string.Format("{0:dd/MM/yyyy}", date);
            else
                return x.TempoPassado();
        }

        public static string TempoPassado(this TimeSpan date)
        {
            if (date.TotalDays > 1)
            {
                return (date.TotalDays.ToInt32() + " dia(s).");
            }
            else if (date.TotalHours > 1)
            {
                return (date.TotalHours.ToInt32() + " hora(s).");
            }
            else if (date.TotalMinutes > 1)
            {
                return (date.TotalMinutes.ToInt32() + " minuto(s).");
            }
            else
            {
                return ("Menos de 1(um) minuto.");
            }
        }


        public static int ToAnoMes(this DateTime data)
        {
            return data.Year * 100 + data.Month;
        }




        public static bool IsAniversario(this DateTime data, DateTime dataComparar)
        {
            return data.Month == dataComparar.Month && data.Day == dataComparar.Day;
        }
        public static bool IsAniversario(this DateTime data)
        {
            return data.IsAniversario(DateTime.Today);
        }
    }
}
