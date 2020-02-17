using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TodoList.BLL.Repositories.Interfaces;
using TodoList.DAL.Entities;

namespace TodoList.BLL.Repositories
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        public TodoRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// The main class has been overridden because Todo has a ISoftDelete class.
        /// </summary>
        public override Todo Get(Expression<Func<Todo, bool>> expression)
        {
            return _dbset.Where(x => !x.IsDeleted).Where(expression).FirstOrDefault();
        }

        /// <summary>
        /// The main class has been overridden because Todo has a ISoftDelete class.
        /// </summary>
        public override IQueryable<Todo> GetAll()
        {
            return _dbset.Where(x => !x.IsDeleted);
        }

        /// <summary>
        /// The main class has been overridden because Todo has a ISoftDelete class.
        /// </summary>
        public override IQueryable<Todo> GetMany(Expression<Func<Todo, bool>> expression)
        {
            return _dbset.Where(x => !x.IsDeleted).Where(expression);
        }
    }
}
