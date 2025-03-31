using BackendProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình MongoDbSettings từ appsettings.json
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Đăng ký MongoDbContext dưới dạng Singleton
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddControllers();

// Cho phép CORS để frontend có thể truy cập API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
