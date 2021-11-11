using Core.Contexts;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.MapperConfiguration;
using API.EventHandlers;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper 
            services.AddAutoMapper(typeof(MappingProfile));

            // Enable CORS 
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigins", options => options.AllowAnyOrigin().AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Controllers
            services.AddControllers();

            // Contexts 
            services.AddDbContext<FightClubContext>(x =>
                x.UseSqlServer(_configuration.GetConnectionString("FightClubConn")));

            // Repositories
            services.RegisterRepositories();

            // Custom services
            services.RegisterServices();

            // Tournament building strategies
            services.RegisterStrategy();

            services.RegisterHandlers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
