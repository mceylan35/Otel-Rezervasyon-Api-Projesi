using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using OtelRezervasyonu.Core.Entities;


namespace OtelRezervasyonu.Entities.Concrete
{
    public class Oda:IEntity
    {

        public Oda()
        {
            Rezervasyon = new HashSet<Rezervasyon>();
        }

        public int Id { get; set; }
        public int OdaNo { get; set; }
        public bool OdaDurumu { get; set; }
        public decimal Ucret { get; set; }
        public int KisiSayisi { get; set; }
        public string Aciklama { get; set; }
        
        public string Resim { get; set; }
        public int OtelId { get; set; }
        public virtual Otel Otel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
