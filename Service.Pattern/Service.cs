using EventPlanner.Data.Infrastructures;
using System.Linq.Expressions;

namespace Service.Pattern
{
    public class Service<T> : IService<T> where T : class
    {

        readonly IUnitOfWork utk;
        public Service(IUnitOfWork utk)
        {
            this.utk = utk;
        }
        public void Commit()
        {
            utk.Commit();
        }
        public void Dispose()
        {
            utk.Dispose();
        }
        public virtual void Add(T entity)
        {
            utk.getRepository<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            utk.getRepository<T>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            utk.getRepository<T>().Delete(where);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return utk.getRepository<T>().Get(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return utk.getRepository<T>().GetAll();
        }

        public virtual T GetById(object Id)
        {
            return utk.getRepository<T>().GetById(Id);
        }

        //public virtual T GetById(string Id)
        //{
        //    return utk.getRepository<T>().GetById(Id);
        //}

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            return utk.getRepository<T>().GetMany(where);
        }

        public virtual void Update(T entity)
        {
            utk.getRepository<T>().Update(entity);
        }
    }
}
