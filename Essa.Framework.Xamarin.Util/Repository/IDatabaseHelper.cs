using SQLite;

namespace Essa.Framework.Util.Repository
{
    public interface IDatabaseHelper
    {
        SQLiteConnection database { get; }
        object locker { get; }
    }
}
