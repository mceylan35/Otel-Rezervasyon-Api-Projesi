using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.Entities;

namespace OtelRezervasyonu.Entities.Concrete
{
   public class Role:IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public int Id { get; set; }
        public string RoleAdi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
