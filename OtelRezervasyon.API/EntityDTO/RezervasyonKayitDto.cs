using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtelRezervasyon.API.EntityDTO
{
    public class RezervasyonKayitDto
    {
        public int Id { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int KisiSayisi { get; set; }  
     
        
       
    }
}
