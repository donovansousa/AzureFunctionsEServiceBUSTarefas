
namespace Aplicacao.Adapters
{
    public interface IAdapt<T, T2> where T : class where T2 : class
    {
        T2 Adapt(T entity);
    }
}
