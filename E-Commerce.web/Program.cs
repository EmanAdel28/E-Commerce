
using System.Reflection.Metadata;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;

using Abstraction;
using Services;
using E_Commerce.web.CustomerMiddlewares;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModel;
using StackExchange.Redis;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Services
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
                return ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnectionString"));
            });
            builder.Services.AddDbContext<StoredIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddScoped<IDbInitilizer,DBInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            builder.Services.AddScoped<IServicesManager, ServiceManager>();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var Errors = context.ModelState.Where(M => M.Value.Errors.Any()).Select(M => new ValidationError()
                    {
                        Field = M.Key,
                        Errors = M.Value.Errors.Select(E => E.ErrorMessage)
                    });
                    var Response = new ValidationErrorToReturn()
                    {
                        ValidationErrors = Errors
                    };
                    return new BadRequestObjectResult(Response);
                };
            });
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<StoredIdentityDbContext>();




            #endregion
            var app = builder.Build();
            #region Configure

            app.UseMiddleware<CustomerExceptionMiddlewares>();


            using var Scope = app.Services.CreateScope();
            var dbInitializer = Scope.ServiceProvider.GetRequiredService<IDbInitilizer>();
            await dbInitializer.InitializerAsync();
            await dbInitializer.IdentityIntializeAsync(();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

         

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseStaticFiles();


            #endregion
            app.Run();

        }
    }
}
