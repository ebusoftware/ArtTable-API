using ArtTableWeb.Application;
using ArtTableWeb.Application.Exceptions;
using ArtTableWeb.Infrastructure;
using ArtTableWeb.Infrastructure.Filters;
using ArtTableWeb.Infrastructure.Services.Storage.Azure;
using ArtTableWeb.Infrastructure.Services.Storage.Local;
using ArtTableWeb.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Service Registration

builder.Services.AddPersistenceService();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddInfrastructureServices();

//Storage

builder.Services.AddStorage<LocalStorage>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Rollendirme.
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Olusturulacak token degerini kimlerin/hangi originlerin/sitelerin kullanıcı belirledigimiz degerdir. -> www.bilmemne.com
            ValidateIssuer = true, //Olusturulacak token deðerini kimin dagıttını ifade edecegimiz alandır. -> www.myapi.com
            ValidateLifetime = true, //Olusturulan token degerinin süresini kontrol edecek olan dogrulamadır.
            ValidateIssuerSigningKey = true, //Üretilecek token degerinin uygulamamıza ait bir deger oldugunu ifade eden suciry key verisinin dogrulanmasıdır.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.

        };
    });




builder.Services.AddControllers();
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

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();//kullanıcı doğrula

app.UseAuthorization();//yetki ver

app.MapControllers();

app.Run();
