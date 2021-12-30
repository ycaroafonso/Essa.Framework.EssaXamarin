namespace Essa.Framework.Util.Interface
{
    public interface IAppVersion
    {
        string GetVersion();
        string GetBuild();


        string GetModoDesenvolvedor();

        string GetAutoTime();
        string GetAutoTimeZone();
    }
}
