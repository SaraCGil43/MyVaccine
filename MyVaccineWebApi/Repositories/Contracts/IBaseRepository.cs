using System.Linq.Expressions;

namespace MyVaccineWebApi.Repositories.Contracts
{
    //Utilizando generics, puede ser cualquier tipo de objeto o clase, facilita extender la funcionalidad de una clase
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task AddRange(List<T> entity);
        Task Update(T entity);
        Task UpdateRange(List<T> entity);
        Task Delete(T entity);
        Task DeleteRange(List<T> entity);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        //Actualizar solo una o varias propiedades de registro, actualizar solo una columna.
        Task Patch(T entity);
        Task PatchRange(List<T> entities);
        //Tipo de metodo y si retorna y no retorna, es una firma. En la logica cambia
        IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate);
    }
}
