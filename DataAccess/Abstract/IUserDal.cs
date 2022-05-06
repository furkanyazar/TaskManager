using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetByUserEmail(string email);
    }
}
