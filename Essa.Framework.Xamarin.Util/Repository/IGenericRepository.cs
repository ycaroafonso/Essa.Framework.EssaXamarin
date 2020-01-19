namespace Essa.Framework.XamarinUtil.Repository
{
    public interface IGenericRepository<T>
    {
        int Incluir(T item);
        void Alterar(T item);
        int Excluir(int id);
    }
}
