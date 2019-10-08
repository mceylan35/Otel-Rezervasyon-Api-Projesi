using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Abstract
{
    public interface IOdaService
    {
        List<Oda> GetAll();
        Oda GetById(int id);
        void Add(Oda entity);
        void Update(Oda entity);
        void Delete(int id);
        List<Oda> Ara(string q);
    }
}
