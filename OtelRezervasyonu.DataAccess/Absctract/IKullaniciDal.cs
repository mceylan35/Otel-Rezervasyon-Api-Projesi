using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Core.DataAccess;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Absctract
{
    public interface IKullaniciDal: IEntityRepository<Kullanici>
    {
        Task<Kullanici> Register(Kullanici kullanici, string password);
        Task<Kullanici> Login(string userName, string password);
        Task<bool> UserExists(string userName);//bu isimde kullanıcı var mı?
    }
}
