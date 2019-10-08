using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Core.DataAccess;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Absctract
{
    public interface IOdaDal:IEntityRepository<Oda>
    {
        List<Oda> Ara(string q);
    }
}
