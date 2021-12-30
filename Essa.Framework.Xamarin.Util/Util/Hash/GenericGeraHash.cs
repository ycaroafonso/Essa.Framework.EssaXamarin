namespace Essa.Framework.Util.Util.Hash
{
    using System;


    [Serializable]
    public abstract class GenericGeraHash : IGeraHash
    {
        private readonly string _chavePrivada;

        public GenericGeraHash() { }
        public GenericGeraHash(string chavePrivada)
        {
            _chavePrivada = chavePrivada;
        }


        public string Hash { get; set; }


        public abstract string ToHashText();

        public virtual void GerarHash()
        {
            Hash = null;
            Hash = new CriptografiaMd5().Encrypt(_chavePrivada + ToHashText());
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


        public void ValidaHash()
        {
            string hashParametro = Hash;
            Hash = null;
            GerarHash();

            ValidaHash(hashParametro);
        }
    }
}
