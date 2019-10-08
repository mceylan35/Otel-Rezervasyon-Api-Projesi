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
    public class RolController : ControllerBase
    {
        private IRoleService _rolService;
        public RolController(IRoleService roleService)
        {
            _rolService = roleService;
        }
        [HttpGet]
        [Route("roller")]
        public IActionResult Roller()
        {
            try
            {
                var roller = _rolService.GetAll();
                return Ok(roller);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("ekle")]
        public IActionResult Ekle(Role rol)
        {
            try
            {
                _rolService.Add(rol);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest(rol);
            }


        }
        [HttpPut]
        [Route("guncelle")]
        public IActionResult Guncelle(Role rol)
        {
            try
            {
                _rolService.Update(rol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(rol);
            }
        }
        [HttpGet]
        [Route("Getir/{id}")]
        public IActionResult Getir(int id)
        {
            try
            {
                var rol = _rolService.GetById(id);
                return Ok(rol);

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
                _rolService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}