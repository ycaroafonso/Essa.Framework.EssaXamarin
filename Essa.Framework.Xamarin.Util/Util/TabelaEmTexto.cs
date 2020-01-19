namespace Essa.Framework.XamarinUtil.Util
{
    using Essa.Framework.XamarinUtil.Extensions;
    using System;
    using System.Collections.Generic;
    using static Essa.Framework.XamarinUtil.Util.TabelaEmTextoColuna;


    public interface ITabelaEmTextoAddColuna
    {

        List<TabelaEmTextoColuna> Colunas { get; set; }

        ITabelaEmTextoAddColuna AddColuna(string titulo, TipoColunaEnum tipoColuna, int? qtdecaracteres = null);
        ITabelaEmTextoAddColuna AddColuna(string titulo, int qtdecaracteres);
        ITabelaEmTextoAddColuna AddColuna(string titulo);

        string MontaCabecalho();

        void CabecalhoWriteLine();
    }


    public interface ITabelaEmTextoAddLinha
    {
        ITabelaEmTextoAddLinha AddRowCell(DateTime v);
        ITabelaEmTextoAddLinha AddRowCell(int v);
        ITabelaEmTextoAddLinha AddRowCell(string v);
        ITabelaEmTextoAddLinha AddRowCell(bool v);
        string MontaLinha();

        void LinhaWriteLine();
    }



    public class TabelaEmTexto : ITabelaEmTextoAddColuna, ITabelaEmTextoAddLinha
    {
        public List<TabelaEmTextoColuna> Colunas { get; set; } = new List<TabelaEmTextoColuna>();


        public ITabelaEmTextoAddColuna AddColuna(string titulo, TipoColunaEnum tipoColuna, int? qtdecaracteres = null)
        {
            switch (tipoColuna)
            {
                case TipoColunaEnum.DataHora:
                    qtdecaracteres = qtdecaracteres ?? 16;
                    break;
                case TipoColunaEnum.SomenteData:
                    qtdecaracteres = qtdecaracteres ?? 10;
                    break;
                case TipoColunaEnum.SomenteHora:
                    qtdecaracteres = qtdecaracteres ?? 5;
                    break;
            }

            Colunas.Add(new TabelaEmTextoColuna
            {
                Titulo = titulo,
                QtdeCaracteres = qtdecaracteres ?? titulo.Length,
                TipoColuna = tipoColuna
            });

            return this;
        }


        public ITabelaEmTextoAddColuna AddColuna(string titulo, int qtdecaracteres)
        {
            Colunas.Add(new TabelaEmTextoColuna
            {
                Titulo = titulo,
                QtdeCaracteres = qtdecaracteres
            });

            return this;
        }

        public ITabelaEmTextoAddColuna AddColuna(string titulo)
        {
            return AddColuna(titulo, titulo.Length);
        }

        public string MontaCabecalho()
        {
            string ret = string.Empty;

            foreach (var item in Colunas)
                ret += item.ToString();

            return ret;
        }
        public void CabecalhoWriteLine()
        {
            Console.WriteLine(MontaCabecalho());
        }



        int _indexCol = 0;
        string _linha = string.Empty;

        private ITabelaEmTextoAddLinha AddRowCell(string v, int indexCol)
        {
            return AddRowCell(v, Colunas[indexCol]);
        }

        private ITabelaEmTextoAddLinha AddRowCell(string v, TabelaEmTextoColuna coluna)
        {
            switch (coluna.TipoColuna)
            {
                case TipoColunaEnum.Inverso:
                    _linha += v
                        .SubstringInversoComReticencia(coluna.QtdeCaracteres)
                        .PadLeft(coluna.QtdeCaracteres) + "|";
                    break;
                default:
                    _linha += v.PadRightComReticencia(coluna.QtdeCaracteres) + "|";
                    break;
            }

            return this;
        }

        public ITabelaEmTextoAddLinha AddRowCell(int v)
        {
            return AddRowCell(v.ToString(), _indexCol++);
        }

        public ITabelaEmTextoAddLinha AddRowCell(string v)
        {
            return AddRowCell(v, _indexCol++);
        }

        public ITabelaEmTextoAddLinha AddRowCell(bool v)
        {
            return AddRowCell(v.ToString(), _indexCol++);
        }

        public ITabelaEmTextoAddLinha AddRowCell(DateTime v)
        {
            if (v.Hour == 0 && v.Minute == 0)
                return AddRowCell(v.ToString("dd/MM/yyyy"), _indexCol++);
            else
                return AddRowCell(v.ToString("dd/MM/yyyy HH:mm"), _indexCol++);
        }


        public string MontaLinha()
        {
            try
            {
                return _linha;
            }
            finally
            {
                _indexCol = 0;
                _linha = string.Empty;
            }
        }
        public void LinhaWriteLine()
        {
            Console.WriteLine(MontaLinha());
        }

    }

    public class TabelaEmTextoColuna
    {
        public enum TipoColunaEnum
        {
            Inverso,
            DataHora,
            SomenteData,
            SomenteHora
        }

        public TipoColunaEnum? TipoColuna { get; set; }

        public string Titulo { get; set; }
        public int QtdeCaracteres { get; set; }

        public override string ToString()
        {
            return Titulo.PadRightComReticencia(QtdeCaracteres) + "|";
        }
    }
}
