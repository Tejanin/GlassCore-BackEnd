

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

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _glassCoreContext.Set<TEntity>().AddRange(entities);
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

        public TEntity Modify(TEntity entity, TEntity dto)
        {
            var entityEntry = _glassCoreContext.Entry(entity);

            // Obtener las propiedades modificadas del DTO que no son null
            var modifiedProperties = typeof(TEntity).GetProperties()
                .Where(prop =>
                {
                    var dtoValue = prop.GetValue(dto);
                    return dtoValue != null && !dtoValue.Equals(prop.GetValue(entity));
                });

            foreach (var property in modifiedProperties)
            {
                var dtoValue = property.GetValue(dto);
                entityEntry.Property(property.Name).CurrentValue = dtoValue;
                entityEntry.Property(property.Name).IsModified = true;
            }

            _glassCoreContext.SaveChanges();

            return entity;
        }


    }
}
