using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using OtelRezervasyonu.Core.DataAccess;
using OtelRezervasyonu.Core.DataAccess.EntityFramework;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Concrete
{
    public class EfOtelDal : EfEntityRepositoryBase<Otel, OtelContext>, IOtelDal
    {

       
    }
}
