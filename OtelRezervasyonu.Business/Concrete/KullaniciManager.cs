using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void Add(Kullanici entity)
        {
           _kullaniciDal.Add(entity);
        }

        public void Delete(int id)
        {
           _kullaniciDal.Delete(id);
        }

        public List<Kullanici> GetAll()
        {
            return _kullaniciDal.GetAll();
        }

        public Kullanici GetById(int id)
        {
            return _kullaniciDal.GetById(id);
        }

        public async Task<Kullanici> Login(string userName, string password)
        {
            return await _kullaniciDal.Login(userName, password);
        }

        public async Task<Kullanici> Register(Kullanici kullanici, string password)
        {
            return await _kullaniciDal.Register(kullanici, password);
        }

        public void Update(Kullanici entity)
        {
           _kullaniciDal.Update(entity);
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _kullaniciDal.UserExists(userName);
        }
    }
}
