using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Angular.Asp.Net.Core.XSRF.RC2.Models;
using Angular.Asp.Net.Core.XSRF.RC2.Repository;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Angular.Asp.Net.Core.XSRF.RC2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
        {
            app.Use(next => context =>
            {
                if (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(context.Request.Path.Value, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() {HttpOnly = false});
                }

                return next(context);
            });


            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc();

        }

    }
}
