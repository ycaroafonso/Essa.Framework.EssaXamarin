namespace Essa.Framework.XamarinSqLite.Interface
{
    using SQLite;


    public interface ISQLite
    {
        string Arquivo { get; }



        SQLiteConnection GetConnectionLocalApplicationData();
        SQLiteConnection GetConnectionPersonal();
    }
}
