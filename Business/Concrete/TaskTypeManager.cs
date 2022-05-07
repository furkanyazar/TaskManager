using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TaskTypeManager : EntityManager<TaskType, ITaskTypeDal>, ITaskTypeService
    {
        public TaskTypeManager(ITaskTypeDal tdal) : base(tdal)
        {
        }
    }
}
