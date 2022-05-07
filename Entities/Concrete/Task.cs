using Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Task : IEntity
    {
        [Key]
        public int TaskId { get; set; }

        public string Description { get; set; }
        public DateTime DateOfInsert { get; set; } = DateTime.Now;
        public DateTime DateOfDeadline { get; set; }
        public bool Status { get; set; } = false;

        public int TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
