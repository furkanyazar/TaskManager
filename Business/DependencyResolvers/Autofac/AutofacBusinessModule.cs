using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<TaskTypeManager>().As<ITaskTypeService>().SingleInstance();
            builder.RegisterType<EfTaskTypeDal>().As<ITaskTypeDal>().SingleInstance();

            builder.RegisterType<TaskManager>().As<ITaskService>().SingleInstance();
            builder.RegisterType<EfTaskDal>().As<ITaskDal>().SingleInstance();
        }
    }
}
