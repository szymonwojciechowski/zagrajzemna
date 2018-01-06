using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZagrajZeMna.Data;

namespace ZagrajZeMna
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BoardGameContext>(cfg =>
            {
                if (Environment.IsEnvironment("macOS"))
                {
                    cfg.UseInMemoryDatabase("BoardGameConnectionString");
                }
                else
                {
                    cfg.UseSqlServer(Configuration.GetConnectionString("BoardGameConnectionString"));
                }
            });
            services.AddAutoMapper();
            services.AddTransient<BoardGameSeeder>();
            services.AddScoped<IBoardGameRepository, BoardGameRepository>();
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (Environment.IsDevelopment() || Environment.IsEnvironment("macOS"))
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<BoardGameSeeder>();
                    seeder.Seed();
                }
            }
        }
    }
}
