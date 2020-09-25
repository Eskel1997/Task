using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitmentTask.API.Auth;
using RecruitmentTask.API.Extensions;
using RecruitmentTask.API.Middleware;
using RecruitmentTask.API.Validation;
using RecruitmentTask.API.ViewModels;
using RecruitmentTask.Core;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using RecruitmentTask.INFRATRUCTURE.Modules;
using RecruitmentTask.INFRATRUCTURE.Services.Abstract;
using RecruitmentTask.INFRATRUCTURE.Services.Concrete;

namespace RecruitmentTask.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<RecruitmentTaskContext>(options =>options.UseInMemoryDatabase("Database"));
            services.AddScoped<RecruitmentTaskContext>();
            services.AddAutoMapper(typeof(EmployeeDTO), typeof(CreateCompanyViewModel));
            services.AddControllers();
            services.AddMediatR(typeof(EmployeeDTO));
            services.AddMvc().AddMvcOptions(fv => fv.EnableEndpointRouting=false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyValidator>());
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddSwagger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseSwaggerExt();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
