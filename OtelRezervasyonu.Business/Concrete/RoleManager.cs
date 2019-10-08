using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void Add(Role entity)
        {
            _roleDal.Add(entity);
        }
        public void Delete(int id)
        {
          _roleDal.Delete(id);
        }
        public List<Role> GetAll()
        {
            return _roleDal.GetAll();
        }
        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }
        public void Update(Role entity)
        {
            _roleDal.Update(entity);
        }
    }
}
