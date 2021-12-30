namespace Essa.Framework.Util.Interface
{
    public interface IUtilGps
    {
        bool IsGpsAtivo { get; }

        void AbrirTelaDeConfiguracaoParaAtivacaoManualDoGps();
    }
}
