using OtelRezervasyonu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OtelRezervasyonu.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);//t veri tipi değil sınıf olarak alır
        
    }
}
