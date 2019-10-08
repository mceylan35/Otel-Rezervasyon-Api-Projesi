using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyonu.Business.Concrete
{
    public class OdaManager : IOdaService
    {
        private IOdaDal _odaDal;

        public OdaManager(IOdaDal odaDal)
        {
            _odaDal = odaDal;
        }

        public void Add(Oda entity)
        {
            _odaDal.Add(entity);
        }

        public List<Oda> Ara(string q)
        {
            return  _odaDal.Ara(q);
        }

        public void Delete(int id)
        {
          _odaDal.Delete(new Oda(){Id = id});
        }

        public List<Oda> GetAll()
        {

            return _odaDal.GetAll();
        }
        public Oda GetById(int id)
        {
            return _odaDal.GetById(id);
        }

        public void Update(Oda entity)
        {
             _odaDal.Update(entity);
        }
    }
}
