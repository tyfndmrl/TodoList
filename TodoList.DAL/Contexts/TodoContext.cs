using System;
using System.Data.Entity;
using System.Linq;
using TodoList.DAL.Entities;
using TodoList.DAL.Entities.Interfaces;

namespace TodoList.DAL.Contexts
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todo { get; set; }

        public TodoContext() : base("DefaultConnection")
        {
        }

        public override int SaveChanges()
        {
            //Entities check the IAuditableEntity and ISoftDelete inherit while saving changes
            var Entries = ChangeTracker.Entries()
                 .Where(x => (x.Entity is IAuditableEntity || x.Entity is ISoftDelete)
                     && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            DateTime now = DateTime.UtcNow;
            foreach (var entry in Entries)
            {
                //if the entity inherit IAuditableEntity
                if (entry.Entity is IAuditableEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = now;
                        entity.EditedDate = now;
                    }
                    else if (entry.State == EntityState.Modified)
                        entity.EditedDate = now;
                }

                //if the entity inherit ISoftDelete
                if (entry.Entity is ISoftDelete softDeletedEntity && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    softDeletedEntity.DeletedDate = now;
                    softDeletedEntity.IsDeleted = true;
                }
            }

            return base.SaveChanges();
        }
    }
}
