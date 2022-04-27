using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Data.Interface;
using SamuraiApp.Data.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//menambahkan automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//menambahkan EF Corenya / Db contextnya
builder.Services.AddDbContext<SamuraiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SamuraiConnection"))
    .EnableSensitiveDataLogging());

//injection object repository
builder.Services.AddScoped<ISamurai, SamuraiRepo>();
builder.Services.AddScoped<IElemen, ElemenRepo>();
builder.Services.AddScoped<IPedang, PedangRepo>();

//konfigurasi jwt
/*var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
