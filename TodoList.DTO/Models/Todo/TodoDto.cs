using System;
using System.ComponentModel.DataAnnotations;
using TodoList.DAL.Entities.Enums;

namespace TodoList.DTO.Models.Todo
{
    public class TodoDto
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
