using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OtelRezervasyonu.Core.DataAccess.EntityFramework;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Concrete
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, OtelContext>, IKullaniciDal
    {

       


        public async Task<Kullanici> Login(string userName, string password)
        {
            using (var _context=new OtelContext())
            {

            var user = await _context.Kullanici.FirstOrDefaultAsync(x => x.KullaniciAdi == userName);
            if (user==null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }

            return user;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                    return false;
                    }
                
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        
        public async Task<Kullanici> Register(Kullanici kullanici, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            kullanici.PasswordHash = passwordHash;
            kullanici.PasswordSalt = passwordSalt;
            using (var _context=new OtelContext())
            {  
            await _context.Kullanici.AddAsync(kullanici);
            await _context.SaveChangesAsync();       
            return kullanici;
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            using (var _context=new OtelContext())
            {
               if (await _context.Kullanici.AllAsync(x=>x.KullaniciAdi==userName))
               {
                return true;
               }
                return false;
            }

        }
    }
}
