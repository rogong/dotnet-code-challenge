using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetTest.Data;
using NetTest.RequestHelpers;
using NetTest.Services;

namespace NetTest
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
            services.AddDbContext<StoreContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();

          services.AddControllers();
          services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DonetTest", Version = "v1" });
            });

            services.AddScoped<DocumentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet Test v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

             app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowCredentials().WithOrigins("http://localhost:3000");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
