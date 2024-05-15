
using DoctorClinicApp.Models;
using DoctorClinicApp.Repositories;
using DoctorClinicApp.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
                options.SuppressModelStateInvalidFilter = true
            );
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DoctorClinicContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });

            builder.Services.AddScoped(typeof(DoctorService));
            builder.Services.AddScoped(typeof(IRepository<Doctor, int>), typeof(DoctorRepository));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            
        }
    }
}
