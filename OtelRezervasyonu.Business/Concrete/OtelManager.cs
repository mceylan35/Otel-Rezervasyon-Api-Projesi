using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Concrete
{
    public class OtelManager : IOtelService
    {
        private IOtelDal _otelDal;

        public OtelManager(IOtelDal otelDal)
        {
            _otelDal = otelDal;
        }
        public void Add(Otel entity)
        {
           _otelDal.Add(entity);
        }

        public void Delete(int id)
        {
            _otelDal.Delete(id);
        }

        public List<Otel> GetAll()
        {
            return _otelDal.GetAll();
        }

        public Otel GetById(int id)
        {
            return _otelDal.GetById(id);
        }

        public void Update(Otel entity)
        {
            _otelDal.Update(entity);

        }
        

        


    }
}
