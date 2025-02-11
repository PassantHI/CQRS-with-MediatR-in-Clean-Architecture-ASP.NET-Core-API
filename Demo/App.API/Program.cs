
using App.Application.Contracts.IRepository;
using App.Infrastructure.Identity;
using App.Infrastructure.Persistence.DatabaseContext;
using App.Infrastructure.Persistence.Repositories;
using App.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            // builder.Services.AddMapster();
            ////mediatR
            //// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            // // Ensure you're referencing the Application project

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(App.Application.AssemblyReference).Assembly));

            //
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddControllers();
            //
            builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CS")));
            //
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:58353",


                    ValidateAudience = true,
                    ValidAudience = "http://localhost:4200",

                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("***********************")),

                };


            });
            ///////////////////////////////////////////////////////////////////

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
