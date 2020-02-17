using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DAL.Entities.Interfaces
{
    /// <summary>
    /// It is used when the creation and modification date of the data is desired to be followed.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Created date
        /// </summary>
        DateTime CreatedDate { get; set; }
        /// <summary>
        /// Edited date
        /// </summary>
        DateTime EditedDate { get; set; }
    }
}
