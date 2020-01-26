using SQLite;

namespace Essa.Framework.Util.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
