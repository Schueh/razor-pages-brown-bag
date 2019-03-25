using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bookstore.Data;
using Microsoft.AspNetCore.Routing;

namespace Bookstore
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
            services.AddMvc()
                // The SetCompatibilityVersion method allows an app to opt-in or opt-out of potentially breaking behavior changes
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/index", "home");
                    options.Conventions.AddPageRoute("/index", "start");
                });

            services.Configure<RouteOptions>(options => 
            {
                options.ConstraintMap.Add("promo", typeof(PromoConstraint));
            });

            services.AddDbContext<BookContext>(options =>
            {
               options.UseInMemoryDatabase("bookTestDb");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // Adds middleware for using HSTS, which adds the Strict-Transport-Security header.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
