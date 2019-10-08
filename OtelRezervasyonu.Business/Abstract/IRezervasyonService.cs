using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Abstract
{
    public interface IRezervasyonService
    {

        List<Rezervasyon> GetAll();
        Rezervasyon GetById(int id);
        void Add(Rezervasyon entity);
        void Update(Rezervasyon entity);
        void Delete(int id);


    }
}
