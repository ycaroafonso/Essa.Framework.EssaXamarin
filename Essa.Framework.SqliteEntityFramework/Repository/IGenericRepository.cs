namespace Essa.Framework.Util.Repository
{
    public interface IGenericRepository<T>
    {
        int Incluir(T item);
        void Alterar(T item);
        int Excluir(T item);
    }
}
