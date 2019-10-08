using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.Entities;

namespace OtelRezervasyonu.Entities.Concrete
{
    //devart
    public class Kullanici:IEntity
    {
        public Kullanici()
        {
            Rezervasyon = new HashSet<Rezervasyon>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
