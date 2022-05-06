using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : EntityManager<User, IUserDal>, IUserService
    {
        public UserManager(IUserDal tdal) : base(tdal)
        {
        }
    }
}
