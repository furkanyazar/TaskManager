using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
