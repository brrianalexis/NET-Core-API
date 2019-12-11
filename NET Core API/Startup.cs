using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//  MongoDB
using MongoDB.Driver;
using MongoDB.Bson;
using ContosoAPI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ContosoAPI.Services;

namespace ContosoAPI
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
            services.Configure<ContosoDBSettings>(Configuration.GetSection(nameof(ContosoDBSettings)));
            services.AddSingleton<IContosoDBSettings>(sp => sp.GetRequiredService<IOptions<ContosoDBSettings>>().Value);
            services.AddSingleton<CoursesService>();
            //  Test
            services.AddSingleton<DepartmentsService>();
            services.AddSingleton<InstructorsService>();
            services.AddSingleton<StudentsService>();
            //services.AddSingleton<CoursesService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}