using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Study.Data;
using System;

namespace Study
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
            // for aspnetcore3.0+

            services.AddRazorPages();
            services.AddControllers();

            services.AddDbContextPool<StudyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StudyDb"));
            });

            services.AddScoped<IStudentData, SqlStudentData>();
            //services.AddScoped<IStudentData, InMemoryStudentData>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(SayHelloMidleWare);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private RequestDelegate SayHelloMidleWare(RequestDelegate next)
        {
            return async context =>
            {
                if (context.Request.Path.StartsWithSegments("/hello")){

                    await context.Response.WriteAsync("Hello world!");
                }
                else
                {
                    await next(context);
                }
                
               
            };
            
        }
    }
}
