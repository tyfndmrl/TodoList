using System;

namespace TodoList.DAL.Entities.Interfaces
{
    /// <summary>
    /// Used if soft deletion is desired in the entity
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Deleted date
        /// </summary>
        DateTime? DeletedDate { get; set; }
        /// <summary>
        /// Is it deleted
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
