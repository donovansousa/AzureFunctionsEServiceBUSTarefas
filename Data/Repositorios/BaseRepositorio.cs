using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        protected DbContext context;

        public BaseRepositorio(DbContext context) => this.context = context;

        public void Adicionar(T objeto)
        {
            this.context.Set<T>().Add(objeto);
            this.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            this.context.Entry(objeto).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Excluir(T objeto)
        {
            this.context.Set<T>().Remove(objeto);
            this.SaveChanges();
        }

        protected void SaveChanges() => this.context.SaveChanges();
    }
}
