using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL.Entities;

namespace TodoList.BLL.Repositories.Interfaces
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {
    }
}
