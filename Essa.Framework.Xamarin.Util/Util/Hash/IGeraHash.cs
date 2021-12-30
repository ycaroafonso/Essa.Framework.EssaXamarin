﻿namespace Essa.Framework.Util.Util.Hash
{
    public interface IGeraHash
    {

        string Hash { get; }

        string ToHashText();


        void GerarHash();

        bool IsHashValido(string hashParametro);

        void ValidaHash(string hashParametro);

        void ValidaHash();
    }
}
