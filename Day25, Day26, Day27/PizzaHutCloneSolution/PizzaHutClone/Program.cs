
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaHutClone.Context;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;
using PizzaHutClone.Repositories;
using PizzaHutClone.Services;

namespace PizzaHutClone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            })
                .ConfigureApiBehaviorOptions(options =>
                options.SuppressModelStateInvalidFilter = true
            );
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };
                });

            #region context_configuration
            builder.Services.AddDbContext<PizzaHutCloneContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
            );
            #endregion


            builder.Services.AddScoped(typeof(UserService));
            builder.Services.AddScoped(typeof(TokenService));
            builder.Services.AddScoped(typeof(PizzaService));
            builder.Services.AddScoped(typeof(AdminService));

            builder.Services.AddScoped(typeof(IRepository<User, int>), typeof(UserRepository));
            builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            builder.Services.AddScoped(typeof(IPizzaRepository), typeof(PizzaRepository));

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
