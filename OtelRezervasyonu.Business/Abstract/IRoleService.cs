using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Add(Role entity);
        void Update(Role entity);
        void Delete(int id);
    }
}
