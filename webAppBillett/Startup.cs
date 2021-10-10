using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webAppBillett.Contexts;
using webAppBillett.DAL;

namespace webAppBillett
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BillettContext>(options => options.UseSqlite("Data source =Billett.db")); //Skal endres etterhvert.
            services.AddSession(options =>
            {

                options.IdleTimeout = System.TimeSpan.FromSeconds(1800); // 30 minutter
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<IBillettRepository, webAppBillett.DAL.BillettRepository>();
            services.AddDistributedMemoryCache();
            services.AddMvc();

            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddFile("Logs/billettLog.txt");
            }

            app.UseStaticFiles(); // merk denne!

            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}