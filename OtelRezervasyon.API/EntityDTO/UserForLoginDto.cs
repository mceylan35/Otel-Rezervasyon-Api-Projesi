using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtelRezervasyon.API.EntityDTO
{
    public class UserForLoginDto
    {
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
    }
}
