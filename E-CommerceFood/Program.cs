
using E_CommerceFood.DAL;
using E_CommerceFood.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Database
            var ConnectionString = builder.Configuration.GetConnectionString("Food");
            builder.Services.AddDbContext<DBContextFood>(options =>
            options.UseSqlServer(ConnectionString,b=>b.MigrationsAssembly("E-CommerceFood"))
            );
            #endregion
            #region IdentityMangers

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DBContextFood>();
            #endregion
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