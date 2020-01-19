namespace Essa.Framework.XamarinUtil.Util.Hash
{
    using Essa.Framework.XamarinUtil.Util;
    using System;


    [Serializable]
    public abstract class GenericGeraHash : IGeraHash
    {
        public string Hash { get; set; }


        public abstract string ToHashText();

        public virtual void GerarHash()
        {
            Hash = null;
            Hash = new CriptografiaMd5().Encrypt(ToHashText());
        }


        public bool IsHashValido(string hashParametro)
        {
            return this.Hash == hashParametro;
        }

        public void ValidaHash(string hashParametro)
        {
            if (!IsHashValido(hashParametro))
                throw new Exception("O hash informado não confere!");
        }
    }
}
