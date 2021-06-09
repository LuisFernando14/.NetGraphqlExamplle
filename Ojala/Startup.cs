using System;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ojala.Queries;
using Microsoft.EntityFrameworkCore;
using Ojala.SchemaGraph;
using Ojala.Types;
using Ojala.Data;
using Ojala.repositories;

namespace Ojala
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
            services.Configure<KestrelServerOptions>(o =>
            {
                o.AllowSynchronousIO = true;
            });

            services.AddSingleton<IServiceProvider>(x => new FuncServiceProvider(x.GetRequiredService));
            services.AddSingleton<Dogs>();
            services.AddSingleton<Dog>();
            // services.AddSingleton<ISchema, GraphSchema>();
            services.AddSingleton<GraphSchema>();
            services.AddGraphQL(x =>
            {
                x.EnableMetrics = true;


            }).AddSystemTextJson(deserializerSettings => { }, serializerSettings => { });
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDBContext")));
            services.AddScoped(typeof(DogRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<GraphSchema>();
            
            app.UseGraphQLPlayground();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
