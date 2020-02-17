using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.Repositories.Interfaces;

namespace TodoList.BLL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Todo: Adding transaction

        ITodoRepository TodoRepository { get; }
        void Save();
    }
}
