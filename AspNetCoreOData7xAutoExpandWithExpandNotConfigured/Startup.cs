using AspNetCoreOData7xAutoExpandWithExpandNotConfigured.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreOData7xAutoExpandWithExpandNotConfigured
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Customer>("Customers");
            modelBuilder.EntitySet<Order>("Orders");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // endpoints.Expand();
                endpoints.MapODataRoute("odata", "odata", modelBuilder.GetEdmModel());
                endpoints.MapControllers();
            });
        }
    }
}
