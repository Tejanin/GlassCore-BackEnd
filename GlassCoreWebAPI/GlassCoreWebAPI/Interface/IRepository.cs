using System.Linq.Expressions;

namespace GlassCoreWebAPI.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);

        TEntity? Get(Expression<Func<TEntity, bool>> filter);

        TEntity Modify(TEntity entity, TEntity dto);

    }
}
