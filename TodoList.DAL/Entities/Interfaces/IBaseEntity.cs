using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DAL.Entities.Interfaces
{
    /// <summary>
    /// Generic type in key id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
