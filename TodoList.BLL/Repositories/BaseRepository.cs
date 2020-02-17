using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TodoList.BLL.Repositories.Interfaces;

namespace TodoList.BLL.Repositories
{
    /// <summary>
    /// Base repository abstract class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly IDbSet<TEntity> _dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public virtual void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        /// <summary>  
        /// Removes the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _dbset.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbset.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
        }

        /// <summary>
        /// Gets the specified predicate.  
        /// </summary>
        /// <param name="expression">The predicate.</param>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.Where(expression).FirstOrDefault();
        }

        /// <summary>  
        /// Gets all.  
        /// </summary> 
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbset;
        }

        /// <summary>  
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>
        public virtual TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }

        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="expression">The predicate.</param>  
        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.Where(expression);
        }

        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>
        public virtual TEntity Add(TEntity entity)
        {
            return _dbset.Add(entity);
        }

        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
