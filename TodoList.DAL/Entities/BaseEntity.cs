using TodoList.DAL.Entities.Interfaces;

namespace TodoList.DAL.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
