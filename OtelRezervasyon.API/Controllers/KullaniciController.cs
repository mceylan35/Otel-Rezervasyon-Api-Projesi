using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OtelRezervasyon.API.EntityDTO;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.Entities.Concrete;

namespace OtelRezervasyon.API.Controllers
{
    [Produces("application/json")]
    [Route("api/kullanici")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {

        private IKullaniciService _kullaniciService;
        private IConfiguration _configuration;
        public KullaniciController(IKullaniciService kullaniciService,IConfiguration configuration)
        {
            _kullaniciService = kullaniciService;
            _configuration = configuration;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto user)
        {
            if (await _kullaniciService.UserExists(user.KullaniciAdi))
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }                           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userToCreate = new Kullanici()
                {
                    KullaniciAdi = user.KullaniciAdi,
                    RoleId = 1,
                    Ad = user.Ad,
                    Soyad = user.Soyad,
                    KayitTarihi = DateTime.Now

                };

                var createdUser = await _kullaniciService.Register(userToCreate, user.Password);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
          

        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var user = await _kullaniciService.Login(userForLoginDto.KullaniciAdi, userForLoginDto.Password);
            if (user==null)
            {
                return Unauthorized();

            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),//kullanıcı İd tutuyoruz
                    new Claim(ClaimTypes.Name,user.KullaniciAdi), // kullanıcı adı tutuyoruz
                    new Claim(ClaimTypes.Role,user.RoleId.ToString())
                }),
                Expires=DateTime.Now.AddDays(1),//1gün
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature) //şifreleme kısmı
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); //tokenı üret
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);


        }

        [HttpGet]
        [Route("kullaniclar")]
        public IActionResult Kullanicilar()
        {
            try
            {
                var kullanicilar = _kullaniciService.GetAll();
                return Ok(kullanicilar);
            }
            catch (Exception)
            {

               return BadRequest();
            }
        }
        [HttpPost]
        [Route("ekle")]
        public IActionResult Ekle(Kullanici kullanici)
        {
            try
            {
                _kullaniciService.Add(kullanici);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest(kullanici);
            }

            
        }
        [HttpPut]
        [Route("guncelle")]
        public IActionResult Guncelle(Kullanici kullanici)
        {
            try
            {
                _kullaniciService.Update(kullanici);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(kullanici);
            }
        }

        [HttpGet]
        [Route("Getir/{id}")]
        public IActionResult Getir(int id)
        {
            try
            {
                var kullanici = _kullaniciService.GetById(id);
                return Ok(kullanici);

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
                _kullaniciService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       

    }
}