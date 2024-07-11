using Microsoft.EntityFrameworkCore;
using PRISM.API.Data;
using PRISM.API.Mappings;
using PRISM.API.Repositories;

namespace PRISM.API
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
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });

            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<IWalkRepository, WalkRepository>();

            // Việc thay thế database khi có sự thay đổi dễ dàng khi triển khai repository
            // Như đoạn code dưới thì đổi từ thao tác với các Entity trong sql thì ta cũng có thể thao tác với
            // một implementation giả cho việc testing, vì vậy không cần chuẩn bị một cơ sở dữ liệu có sẵn
            //builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(AutoMapProfiles));

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