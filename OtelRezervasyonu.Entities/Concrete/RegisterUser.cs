using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonu.Entities.Concrete
{
    public class RegisterUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KullaniciAdi { get; set; }
    }
}
