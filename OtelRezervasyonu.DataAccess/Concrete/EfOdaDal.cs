using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OtelRezervasyonu.Core.DataAccess.EntityFramework;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.DataAccess.Concrete
{
    public class EfOdaDal:EfEntityRepositoryBase<Oda, OtelContext>,IOdaDal
    {
        public List<Oda> Ara(string q)
        {
            using (var context=new OtelContext())
            {
                var oteller =  context.Oda.Where(i => i.Aciklama.Contains(q)).ToList();

                if (oteller==null)
                {
                    return null;
                }
               
                return oteller;
            }
        }

       
    }
}
