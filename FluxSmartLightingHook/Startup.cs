using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace FluxSmartLightingHook
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
                {
                    var ct = context.Request.Query["ct"];
                    var bri = context.Request.Query["bri"];

                    Debug.WriteLine($"Color temperature (ct): {ct}");
                    Debug.WriteLine($"Brightness (bri): {bri}");

                    await context.Response.WriteAsync(string.Empty);
                });
            });
        }
    }
}
