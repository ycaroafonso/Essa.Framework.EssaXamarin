using SQLite;

namespace Essa.Framework.XamarinSqLite.Repository
{
    public interface IDatabaseHelper
    {
        SQLiteConnection database { get; }
        object locker { get; }
    }
}
