using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TodoList.DAL.Entities;

namespace TodoList.BLL.Repositories.Interfaces
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>  
        /// Gets all.  
        /// </summary> 
        IQueryable<TEntity> GetAll();
        /// <summary>  
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>
        TEntity GetById(int id);
        /// <summary>
        /// Gets the specified predicate.  
        /// </summary>
        /// <param name="expression">The predicate.</param>
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="expression">The predicate.</param>  
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);
        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void Update(TEntity entity);
        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>
        TEntity Add(TEntity entity);
        /// <summary>  
        /// Removes the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        void Delete(int id);
        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void Delete(TEntity entity);
    }
}
