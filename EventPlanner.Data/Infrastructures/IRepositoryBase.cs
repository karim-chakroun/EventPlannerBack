using System.Linq.Expressions;

namespace EventPlanner.Data.Infrastructures
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(object Id);
        //T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(); // GetMany()
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null);
    }
}
