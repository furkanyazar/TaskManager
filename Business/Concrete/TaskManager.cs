﻿using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TaskManager : EntityManager<Task, ITaskDal>, ITaskService
    {
        public TaskManager(ITaskDal tdal) : base(tdal)
        {
        }

        public List<Task> GetAllByTypeIdAndUserId(int typeId, int userId)
        {
            return _tdal.GetAll(x => x.TaskTypeId == typeId && x.UserId == userId);
        }
    }
}
