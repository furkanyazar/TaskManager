using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepository<User, TaskManagerDbContext>, IUserDal
    {
        public User GetByUserEmail(string email)
        {
            using TaskManagerDbContext context = new();

            return context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}
