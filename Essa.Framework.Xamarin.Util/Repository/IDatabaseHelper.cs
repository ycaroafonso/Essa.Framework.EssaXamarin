using SQLite;

namespace Essa.Framework.XamarinUtil.Repository
{
    public interface IDatabaseHelper
    {
        SQLiteConnection database { get; }
        object locker { get; }
    }
}
