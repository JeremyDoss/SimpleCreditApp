﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CreditApp.Infrastructure;
using System.IO;
using Microsoft.EntityFrameworkCore;
using CreditApp.Repositories.Interfaces;
using CreditApp.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace CreditApp.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbPath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "data"), "credit-app.db");
            string connection = $"Data Source={dbPath}";

            services.AddDbContext<CreditDbContext>(options => options.UseSqlite(connection));

            // Add framework services.
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Credit API", Version = "v1" });
            });

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credit App V1");
            });
        }
    }
}
