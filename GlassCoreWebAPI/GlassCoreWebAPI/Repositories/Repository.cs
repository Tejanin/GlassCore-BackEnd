

using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GlassCoreWebAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GlassCoreContext _glassCoreContext;
      
        public Repository(GlassCoreContext glassCoreContext)
        {
            _glassCoreContext = glassCoreContext;
            
        }

        public void Create(TEntity entity)
        {
            _glassCoreContext.Set<TEntity>().Add(entity);
            _glassCoreContext.SaveChanges();
        }

        
        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return _glassCoreContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _glassCoreContext.Set<TEntity>().ToList();
        }

        
    }
}
