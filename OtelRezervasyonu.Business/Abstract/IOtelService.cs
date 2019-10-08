using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Abstract
{
     public interface IOtelService
    {
        List<Otel> GetAll();
        Otel GetById(int id);
        void Add(Otel entity);
        void Update(Otel entity);
        void Delete(int id);
    }
}
