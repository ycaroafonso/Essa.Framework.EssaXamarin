namespace Essa.Framework.XamarinUtil.Util
{
    using Extensions;
    using System;


    public class AnoMesUtil
    {
        private int _anomes;

        public int AnoMes
        {
            get
            {
                return _anomes;
            }
            set
            {
                Ano = (value / 100).ToInt32();
                Mes = value - (Ano * 100);
                _anomes = value;
            }
        }

        public int Ano { get; private set; }
        public int Mes { get; private set; }



        public AnoMesUtil(int anomes)
        {
            AnoMes = anomes;
        }
        public AnoMesUtil(int ano, int mes)
        {
            Ano = ano;
            Mes = mes;

            AnoMes = ano * 100 + mes;
        }

        public int AddMes(int qtdeMeses)
        {
            AnoMes = ToDateTime(1).AddMonths(qtdeMeses).ToAnoMes();
            return AnoMes;
        }


        public DateTime ToDateTime(int dia = 1)
        {
            return new DateTime(Ano, Mes, dia);
        }

        public string ToStringFormatado(string formato = "MM/yyyy")
        {
            return ToDateTime().ToString(formato);
        }
    }
}
