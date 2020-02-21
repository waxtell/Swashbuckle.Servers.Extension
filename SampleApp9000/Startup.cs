using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.Servers.Extension;

namespace SampleApp9000
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    "sampleapp",
                    new OpenApiInfo
                    {
                        Title = "Sample App 9000",
                        Version = "1.0.0",
                        Description = "Provides a simple example of the tool"
                    }
                );

                c.WithServers
                (
                    new List<OpenApiServer>
                    {
                        new OpenApiServer { Url = "http://localhost:5000" },
                        new OpenApiServer { Url = "https://www.yourcustomdomain.com" }
                    }
                );
            });
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

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(x =>
            {
                x.DocumentTitle = "SampleApp9000";
                x.SwaggerEndpoint("/swagger/sampleapp/swagger.json", "Sample App 9000");
                x.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
