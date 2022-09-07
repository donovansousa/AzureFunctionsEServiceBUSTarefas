namespace Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<T> where T : class
    {
        void Adicionar(T objeto);
        void Atualizar(T objeto);
        void Excluir(T objeto);
    }
}
