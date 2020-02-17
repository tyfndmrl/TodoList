using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.DAL.Entities.Enums;
using TodoList.DAL.Entities.Interfaces;

namespace TodoList.DAL.Entities
{
    [Table("Todo")]
    public class Todo : BaseEntity<int>, IAuditableEntity, ISoftDelete
    {
        [StringLength(150)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
