namespace Essa.Framework.XamarinSqLite.Repository
{
    public interface IGenericRepository<T>
    {
        int Incluir(T item);
        void Alterar(T item);
        int Excluir(int id);
    }
}
