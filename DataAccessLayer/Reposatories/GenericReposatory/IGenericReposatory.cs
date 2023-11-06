using System.Linq.Expressions;

namespace DataAccessLayer.Reposatories
{
    public interface IGenericReposatory<T> where T : class
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void insert(T Entity);
        void update(T Entity);
        void Delete(int id);
        int save();
    }
}
