using SQLite;
using System;

namespace Essa.Framework.Util.Repository
{
    public interface IDatabaseHelper
    {
        SQLiteConnection database { get; }
        object locker { get; }


        [Obsolete("Utilizar Personal();")]
        IDatabaseHelper LocalApplicationData();

        IDatabaseHelper Personal();


        IDatabaseHelper Memory();
    }
}
