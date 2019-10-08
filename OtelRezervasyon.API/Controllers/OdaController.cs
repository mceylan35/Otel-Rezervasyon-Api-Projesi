using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtelRezervasyon.API.EntityDTO;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyon.API.Controllers
{
    [Route("api/oda")]
    [ApiController]
    public class OdaController : ControllerBase
    {
        private IOdaService _odaService;
        private IRezervasyonService _rezervasyonService;
        public OdaController(IOdaService odaService,IRezervasyonService rezervasyonService)
        {
            _odaService = odaService;
            _rezervasyonService = rezervasyonService;
        }
        [HttpGet]
        [Route("odalar")]
        public ActionResult Odalar()
        {
            var tumrezerveler = _rezervasyonService.GetAll().ToList();
            foreach (var rezerve in tumrezerveler)
            {
                TimeSpan fark = DateTime.Now - rezerve.CikisTarihi;
                if (rezerve.CikisTarihi < DateTime.Now && fark.Days>=1)
                {
                    var oda = _odaService.GetById(rezerve.OdaId);
                    
                    if (oda.OdaDurumu == false)
                    {
                        oda.OdaDurumu = true;
                        _odaService.Update(oda);
                    }


                }
            }
            //Rezervasyon COntrollerıdaki rezervasyonu güncelleyerek sorunu çözebilirsin.

            var odalar = _odaService.GetAll().Where(i=>i.OdaDurumu==true).ToList();
            return Ok(odalar);
        }
        [HttpPost]
        [Route("ekle")]
        public ActionResult OdaEkle([FromBody]Oda oda)
        {
           
            _odaService.Add(oda);

            return Ok(oda);
        }
        [HttpGet]
        [Route("getir/{id}")]
        public ActionResult OdaGetir(int id)
        {
            var oda = _odaService.GetById(id);

            return Ok(oda);
        }
        [HttpPut]
        [Route("guncelle")]
        public IActionResult OdaGuncelle(Oda oda)
        {
            try
            {
                _odaService.Update(oda);
                return Ok(oda);
            }
            catch (Exception)
            {

              
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("sil/{id}")]
        public IActionResult OdaSil(int id)
        {
            try
            {
                _odaService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

              return  NotFound("Bulunamadı");
            }
        }
        [HttpGet]
        [Route("ara/{q}")]
        public IActionResult Ara(string q)
        {
            try
            {
                var odalar = _odaService.Ara(q).ToList();
                return Ok(odalar);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}