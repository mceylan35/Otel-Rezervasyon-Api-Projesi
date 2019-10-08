using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.DataAccess;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Absctract
{
    public interface IRezervasyonDal:IEntityRepository<Rezervasyon>
    {
    }
}
