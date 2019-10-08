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
    [Route("api/rezervasyon")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {

        private IRezervasyonService _rezervasyonService;
        private IOdaService _odaService;
        public RezervasyonController(IRezervasyonService rezervasyonService, IOdaService odaService)
        {
            _odaService = odaService;
            _rezervasyonService = rezervasyonService;

        }
        [HttpGet]
        [Route("rezervasyonlar/{id}")]
        public IActionResult Rezervasyonlar(int id=1)
        {
            try
            {
                var rezervasyonlar = _rezervasyonService.GetAll().Where(i=>i.KullaniciId==id).ToList();
                return Ok(rezervasyonlar);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("ekle")]
        public IActionResult Ekle(Rezervasyon rezervasyon)
        {
            try
            {
                var oda = _odaService.GetById(rezervasyon.OdaId);
                oda.OdaDurumu = false;
               
                _odaService.Update(oda);
                TimeSpan fark = (rezervasyon.CikisTarihi - rezervasyon.GirisTarihi);
                rezervasyon.ToplamFiyat = ((int)fark.TotalDays+1) * rezervasyon.ToplamFiyat;
                _rezervasyonService.Add(rezervasyon);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest(rezervasyon);
            }


        }
        [HttpPut]
        [Route("guncelle")]
        public IActionResult Guncelle(Rezervasyon rezervasyon)
        {
            try
            {
                _rezervasyonService.Update(rezervasyon);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(rezervasyon);
            }
        }
        [HttpGet]
        [Route("Getir/{id}")]
        public IActionResult Getir(int id)
        {
            try
            {
                var rezervasyon = _rezervasyonService.GetById(id);
                return Ok(rezervasyon);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("sil/{id}")]
        public IActionResult Sil(int id)
        {
            try
            {
                _rezervasyonService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("odaara")]
        public IActionResult RezervasyonKayit([FromBody]RezervasyonKayitDto rezervasyonKayit)
        {
            try
            {
                var test = _odaService.GetAll();
                var odalar = _odaService.GetAll().Where(i => i.KisiSayisi == rezervasyonKayit.KisiSayisi && i.OdaDurumu == true).ToList();
              
                if (odalar==null)
                {
                    return null;
                }
                return Ok(odalar);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}