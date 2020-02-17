using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.Repositories;
using TodoList.BLL.Repositories.Interfaces;
using TodoList.BLL.UnitOfWork.Interfaces;

namespace TodoList.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed = false;
        public ITodoRepository TodoRepository { get; }

        public UnitOfWork(DbContext context, ITodoRepository todoRepository)
        {
            _context = context;
            TodoRepository = todoRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
