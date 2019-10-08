using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Core.DataAccess.EntityFramework;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Concrete
{
    public class EfRezervasyonDal : EfEntityRepositoryBase<Rezervasyon, OtelContext>, IRezervasyonDal
    {
    }
}
