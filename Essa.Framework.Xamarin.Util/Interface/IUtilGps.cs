namespace Essa.Framework.Util.Interface
{
    public interface IUtilGps
    {
        bool IsProviderEnabled { get; }

        void AbrirConfiguracao();
    }
}
