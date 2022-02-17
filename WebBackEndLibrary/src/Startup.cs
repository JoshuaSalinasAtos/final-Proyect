using BookRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackEndLibrary.Configurations;
using WebBackEndLibrary.Repositories;
using WebBackEndLibrary.Repositories.Implementation;
using WebBackEndLibrary.Services;
using WebBackEndLibrary.Services.Implementation;

namespace WebBackEndLibrary
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
            //Database configuration
            //Server=localhost;Database=db_upgrade;User Id=sa;Password=******;
            //Console.WriteLine(Configuration.GetConnectionString("CourseConnection"));
            services.AddDbContext<EntityContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));
            //options => options.UseInMemoryDatabase("WebBackEndAPI"));


            //Repositories
            //----BookS------//
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Program));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebBackEndLibrary", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //get protos
                endpoints.MapGet("protos/Books.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Remote/Grpc/Server/Protos/Books.proto"));
                });

                endpoints.MapControllers();
            });

            //Aqu� se configura la base de datos (Iniciando migraci�n)
            //MigrationRunner.Run(app);
        }
    }
}
