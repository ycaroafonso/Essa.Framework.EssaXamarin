using SQLite;

namespace Essa.Framework.XamarinUtil.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
