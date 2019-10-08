using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtelController : ControllerBase
    {

        private IOtelService _otelService;
        public OtelController(IOtelService otelService)
        {
            _otelService = otelService;
        }
        [HttpGet]
        [Route("oteller")]
        public IActionResult Oteller()
        {
            try
            {
                var oteller = _otelService.GetAll();
                return Ok(oteller);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("ekle")]
        public IActionResult Ekle(Otel otel)
        {
            try
            {
                _otelService.Add(otel);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest(otel);
            }


        }
        [HttpPut]
        [Route("guncelle")]
        public IActionResult Guncelle(Otel otel)
        {
            try
            {
                _otelService.Update(otel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(otel);
            }
        }
        [HttpGet]
        [Route("Getir/{id}")]
        public IActionResult Getir(int id)
        {
            try
            {
                var otel = _otelService.GetById(id);
                return Ok(otel);

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
                _otelService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}