using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITaskService : IEntityService<Task>
    {
        List<Task> GetAllByUserId(int userId);

        Task GetById(int id);
    }
}
