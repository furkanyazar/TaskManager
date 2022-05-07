using Core.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TaskType : IEntity
    {
        [Key]
        public int TaskTypeId { get; set; }

        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public List<Task> Tasks { get; set; }
    }
}
