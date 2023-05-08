using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Models.Interfaces;
using Shop.Models.Mocks;
using Shop.Repository;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _dbConfig;
        public Startup(IHostEnvironment hosting)
        {
            _dbConfig = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => 
                options.UseSqlServer(_dbConfig.GetConnectionString("DefaultConnection")));

            services.AddTransient<IProducts, ProductRepository>();
            services.AddTransient<ICategory, CategoryRepository>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp => );
            services.AddSession();

            services.AddMvc();   
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "showpage",
                    pattern: "{controller=Login}/{action=Workspace}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetService<AppDBContent>();
                DbInitial.Initial(content);
            }
        }
    }
}
