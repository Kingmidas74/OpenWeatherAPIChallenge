using System;
using BusinessServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using WebAPIService.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Prometheus;
using Masking.Serilog;
using DataAccess;

namespace WebAPIService
{   
    public class Startup {
        private readonly string CorsPolicy = nameof (CorsPolicy);
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;          
        }

        private JsonSerializerSettings ConfigureJSON() {
            var result = new JsonSerializerSettings () {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver (),
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore                
            };
            result.Converters.Add(new StringEnumConverter());
            return result;
        }

        public void ConfigureServices (IServiceCollection services) {
            JsonConvert.DefaultSettings = ConfigureJSON;
            services.AddSwagger ();       
            services.AddBusinessServices();
            services.AddWeatherClient();
            services.AddSingleton<MetricReporter>();

            services.AddControllers ()
                .AddNewtonsoftJson (options => {
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddCors (options => {
                options.AddPolicy (nameof (CorsPolicy),
                    builder => builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .Build ());
            });
        }

        public void Configure (IApplicationBuilder app, IApiVersionDescriptionProvider provider) {
            Log.Logger = new LoggerConfiguration ().ReadFrom.Configuration (Configuration).CreateLogger();
            
            app.UseMiddleware<RequestResponseLoggingMiddleware> ();
            app.UseMiddleware<ResponseMetricMiddleware>();
            app.UseMiddleware<CountRequestMiddleware>();
            
            app.UseStaticFiles();            

            app.UseCors (nameof (CorsPolicy));
            app.UseMetricServer(); 
            app.UseCustomExceptionHandler();
            app.UseHttpMetrics();
            app.UseDeveloperExceptionPage();  
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    c.SwaggerEndpoint ($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    c.RoutePrefix = "swagger";                    
                }
                
            });

            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}