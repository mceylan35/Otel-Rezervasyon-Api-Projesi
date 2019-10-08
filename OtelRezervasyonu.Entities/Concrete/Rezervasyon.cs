using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.Entities;

namespace OtelRezervasyonu.Entities.Concrete
{
    public class Rezervasyon:IEntity
    {
        public int Id { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public int KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public int OdaId { get; set; }
        public virtual Oda Oda { get; set; }
    }
}
