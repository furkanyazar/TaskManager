using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class TaskManager : EntityManager<Task, ITaskDal>, ITaskService
    {
        public TaskManager(ITaskDal tdal) : base(tdal)
        {
        }

        public List<Task> GetAllByUserId(int userId)
        {
            return _tdal.GetAll(x => x.UserId == userId).OrderBy(x => x.DateOfInsert).ToList();
        }

        public Task GetById(int id)
        {
            return _tdal.Get(x => x.TaskId == id);
        }
    }
}
