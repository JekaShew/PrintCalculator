using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrintCalculator.Abstract.PaperInterfaces;
using PrintCalculator.Data;
using PrintCalculator.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using PrintCalculator.Services.PaperServices;
using PrintCalculator.FileStorage.Abstract;
using PrintCalculator.FileStorage;
using PrintCalculator.Abstract.StorageInterfaces;
using PrintCalculator.Services.StorageServices;
using PrintCalculator.Abstract.TechProcessInterfaces;
using PrintCalculator.Services.TechProcessServices;
using PrintCalculator.Abstract.PostPrintInterfaces;
using PrintCalculator.Services.PostPrintServices;

namespace PrintCalculator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Services.AutoMapper));
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(@"Server=DESKTOP-DUQNODG\SQLEXPRESS;Database=PrintCalculator;Trusted_Connection=True;"));
            services.AddMvc();
            services.AddCors();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "PrintCalculator Web API" });
                x.TagActionsBy(api =>
                {
                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor == null)
                        throw new InvalidOperationException("Unable to determine tag for endpoint.");

                    if (api.GroupName != null)
                        return new[] { $"{api.GroupName} {controllerActionDescriptor.ControllerName}" };

                    return new[] { controllerActionDescriptor.ControllerName };
                });
                x.DocInclusionPredicate((name, api) => true);
            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //       .AddJwtBearer(options =>
            //       {
            //           options.RequireHttpsMetadata = false;
            //           options.TokenValidationParameters = new TokenValidationParameters
            //           {
            //               ValidateIssuer = true,
            //               ValidIssuer = Constants.Identity.ISSUER,

            //               ValidateAudience = true,
            //               ValidAudience = Constants.Identity.AUDIENCE,
            //               ValidateLifetime = true,

            //               IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Constants.Identity.KEY)),
            //               ValidateIssuerSigningKey = true,
            //           };
            //       });

            services.AddStorageServices<NoStorage>();
            services.AddTransient<DbContext>(isp => isp.GetService<AppDBContext>());

            services.AddTransient<IPaperServices, PaperServices>();
            services.AddTransient<IPaperClassServices, PaperClassServices>();
            services.AddTransient<IPaperSizeServices, PaperSizeServices>();
            services.AddTransient<IPaperCoefficientServices, PaperCoefficientServices>();
            services.AddTransient<IPaperDensityServices, PaperDensityServices>();
            services.AddTransient<IPaperFormatServices, PaperFormatServices>();
            services.AddTransient<IPaperTypeServices, PaperTypeServices>();
            services.AddTransient<IPaperPriceGroupServices, PaperPriceGroupServices>();

            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<ISubCategoryServices, SubCategoryServices>();
            services.AddTransient<IUnitMeasureServices, UnitMeasureServices>();
            services.AddTransient<IStorageServices, StorageServices>();
            services.AddTransient<IStorageProductServices, StorageProductServices>();

            services.AddTransient<IOptionServices, OptionServices>();
            services.AddTransient<IPrintTypeServices, PrintTypeServices>();
            services.AddTransient<ISectorServices, SectorServices>();
            services.AddTransient<ITechProcessServices, TechProcessServices>();
            services.AddTransient<ITechProcessOptionServices, TechProcessOptionServices>();

            services.AddTransient<IPostPrintGroupServices, PostPrintGroupServices>();
            services.AddTransient<IPackagingTypeServices, PackagingTypeServices>();
            services.AddTransient<IPostPrintOperationServices, PostPrintOperationServices>();
            services.AddTransient<IPostPrintPriceServices, PostPrintPriceServices>();
            services.AddTransient<IPostPrintPriceGroupServices, PostPrintPriceGroupServices>();
            services.AddTransient<IPostPrintTargetServices, PostPrintTargetServices>();



            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDBContext appDBContext)
        {
            app.UseHttpsRedirection();
            appDBContext.Database.EnsureCreated();
            //appDBContext.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true)
                .AllowCredentials().WithExposedHeaders("Set-Cookie", "set-cookie"));
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintCalculator Web API"));

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
