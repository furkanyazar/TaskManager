using Core.DataAccess;
using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Core.Business
{
    public class EntityManager<TEntity, TDal> : IEntityService<TEntity> where TEntity : class, IEntity, new() where TDal : IEntityRepository<TEntity>
    {
        public TDal _tdal;

        public EntityManager(TDal tdal)
        {
            _tdal = tdal;
        }

        public void Add(TEntity entity)
        {
            _tdal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _tdal.Delete(entity);
        }

        public List<TEntity> GetAll()
        {
            return _tdal.GetAll();
        }

        public void Update(TEntity entity)
        {
            _tdal.Update(entity);
        }
    }
}
