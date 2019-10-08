using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OtelRezervasyonu.Business.Abstract;
using OtelRezervasyonu.Business.Concrete;
using OtelRezervasyonu.DataAccess.Absctract;
using OtelRezervasyonu.DataAccess.Concrete;

namespace OtelRezervasyon.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);

            
            
            services.AddScoped<IOdaService, OdaManager>();
            services.AddScoped<IOdaDal, EfOdaDal>();
            services.AddScoped<IOtelService, OtelManager>();
            services.AddScoped<IOtelDal, EfOtelDal>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IRezervasyonService, RezervasyonManager>();
            services.AddScoped<IRezervasyonDal, EfRezervasyonDal>();
            services.AddScoped<IKullaniciService, KullaniciManager>();
            services.AddScoped<IKullaniciDal, EfKullaniciDal>();

            services.AddMvc().AddJsonOptions(opt=> 
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience=false,
                };
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
