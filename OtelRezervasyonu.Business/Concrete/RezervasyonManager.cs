using System;
using System.Collections.Generic;
using System.Text;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Concrete
{
    public class RezervasyonManager : IRezervasyonService
    {
        private IRezervasyonDal _rezervasyonDal;

        public RezervasyonManager(IRezervasyonDal rezervasyonDal)
        {
            _rezervasyonDal = rezervasyonDal;
        }

        public void Add(Rezervasyon entity)
        {
           _rezervasyonDal.Add(entity);
        }

        public void Delete(int id)
        {
           _rezervasyonDal.Delete(id);
        }

        public List<Rezervasyon> GetAll()
        {
           return _rezervasyonDal.GetAll();
        }

        public Rezervasyon GetById(int id)
        {
            return _rezervasyonDal.GetById(id);
        }

        public void Update(Rezervasyon entity)
        {
           _rezervasyonDal.Update(entity);
        }

       

    }
}
