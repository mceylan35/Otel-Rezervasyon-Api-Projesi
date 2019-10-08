using OtelRezervasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonu.Business.Abstract
{
    public interface IKullaniciService
    {
        List<Kullanici> GetAll();
        Kullanici GetById(int id);
        void Add(Kullanici entity);
        void Update(Kullanici entity);
        void Delete(int id);
        Task<Kullanici> Register(Kullanici kullanici, string password);
        Task<Kullanici> Login(string userName, string password);
        Task<bool> UserExists(string userName);//bu isimde kullanıcı var mı?

    }
}
