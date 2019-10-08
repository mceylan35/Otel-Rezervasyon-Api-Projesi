using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.Entities;


namespace OtelRezervasyonu.Entities.Concrete
{
    public class Otel:IEntity
    {
        public Otel()
        {
            Odalar = new List<Oda>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Adres { get; set; }
        public int Puan { get; set; }
        public string Resim { get; set; }
        public virtual List<Oda> Odalar { get; set; }
    }
}
