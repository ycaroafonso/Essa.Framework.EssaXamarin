namespace Essa.Framework.Util.Repository
{
    using SQLite;
    using System.Collections.Generic;


    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected SQLiteConnection Contexto;
        protected readonly object locker;

        public GenericRepository(IDatabaseHelper db)
        {
            Contexto = db.database;

            locker = db.locker;

            Contexto.CreateTable<T>();
        }


        public abstract TableQuery<T> ObterTodos();


        public int Incluir(T item)
        {
            lock (locker)
            {
                return Contexto.Insert(item);
            }
        }

        public void Incluir(List<T> lista)
        {
            lock (locker)
            {
                Contexto.InsertAll(lista);
            }
        }

        public void Alterar(T item)
        {
            lock (locker)
            {
                Contexto.Update(item);
            }
        }

        public void Alterar(ICollection<T> lista)
        {
            lock (locker)
            {
                Contexto.UpdateAll(lista);
            }
        }

        public int Excluir(int id)
        {
            lock (locker)
            {
                return Contexto.Delete<T>(id);
            }
        }

        public List<TQuery> SqlQuery<TQuery>(string sql, params object[] args) where TQuery : class, new()
        {
            return Contexto.Query<TQuery>(sql, args);
        }
    }
}
