namespace Essa.Framework.XamarinUtil.Interface
{
    public interface IUtilGps
    {
        bool IsProviderEnabled { get; }

        void AbrirConfiguracao();
    }
}
