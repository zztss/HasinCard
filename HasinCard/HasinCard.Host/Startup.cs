﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HasinCard.Core.AuoMapper;
using HasinCard.Core.Validator.SysUser;
using HasinCard.Data;
using HasinCard.Service.SysUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HasinCard.Host
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
            services.AddMvc();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<HasinCardDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));
            services.AddScoped<ISysUserService, SysUserService>();

            services.AddAuthentication("Bearer")
             .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = "http://localhost:5680";
                 options.RequireHttpsMetadata = false;

                 options.ApiName = "apihost";
             });

            services.AddCors(options =>
            {
                //允许任何站点跨域
                options.AddPolicy("any", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("any");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
