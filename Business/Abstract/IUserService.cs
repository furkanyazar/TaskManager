using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        User GetByUserEmail(string email);

        User GetById(int id);
    }
}
