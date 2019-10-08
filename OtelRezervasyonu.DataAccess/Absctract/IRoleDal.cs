using OtelRezervasyonu.Core.DataAccess;
using OtelRezervasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonu.DataAccess.Absctract
{
     public interface IRoleDal:IEntityRepository<Role>
    {
    }
}
