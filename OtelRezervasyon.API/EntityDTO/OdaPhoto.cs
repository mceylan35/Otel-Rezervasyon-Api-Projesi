using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtelRezervasyon.API.EntityDTO
{
    public class OdaPhoto
    {
        public int Id { get; set; }
        public int OdaNo { get; set; }
        public bool OdaDurumu { get; set; }
        public decimal Ucret { get; set; }
        public int KisiSayisi { get; set; }
        public string Aciklama { get; set; }
        public IFormFile Resim { get; set; }
        //  public string Resim { get; set; }
        public int OtelId { get; set; }
    }
}
