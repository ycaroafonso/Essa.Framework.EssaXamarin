namespace Essa.Framework.Util.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class GenericRepository<TContext, T> : IGenericRepository<T>
        where T : class
        where TContext : DbContext
    {
        public TContext Contexto { get; }


        public GenericRepository(TContext contexto)
        {
            Contexto = contexto;
        }


        public List<T> ObterTodos()
        {
            return Contexto.Set<T>().ToList();
        }


        public int Incluir(T item)
        {
            Contexto.Set<T>().Add(item);
            return Contexto.SaveChanges();
        }

        public void Incluir(List<T> lista)
        {
            Contexto.Set<T>().AddRange(lista);
            Contexto.SaveChanges();
        }

        public void Alterar(T item)
        {
            Contexto.Set<T>().Update(item);
            Contexto.SaveChanges();
        }

        public void Alterar(ICollection<T> lista)
        {
            Contexto.Set<T>().UpdateRange(lista);
            Contexto.SaveChanges();
        }

        public int Excluir(T item)
        {
            Contexto.Set<T>().Remove(item);
            return Contexto.SaveChanges();
        }

        public List<TQuery> SqlQuery<TQuery>(string sql, params object[] args) where TQuery : class, new()
        {
            //return Contexto.Database.sql<TQuery>(sql, args);
            throw new System.Exception();
        }
    }
}
