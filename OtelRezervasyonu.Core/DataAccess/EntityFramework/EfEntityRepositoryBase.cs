using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OtelRezervasyonu.Core.Entities;

namespace OtelRezervasyonu.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, OtelContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where OtelContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            using (var context=new OtelContext())
            {
               var addedEntry= context.Entry(entity);
                addedEntry.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            using (var context=new OtelContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var contect=new OtelContext())
            {
                return contect.Set<TEntity>().SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context= new OtelContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new OtelContext())
            {
                return id != null
                    ? context.Set<TEntity>().Find(id)
                :null;
            }
        }

        public void Update(TEntity entity)
        {
            using (var context=new OtelContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
