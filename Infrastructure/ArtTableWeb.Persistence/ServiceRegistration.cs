﻿using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Services;
using ArtTableWeb.Application.Services.Authentications;
using ArtTableWeb.Domain.Entities;
using ArtTableWeb.Domain.Entities.Identity;
using ArtTableWeb.Persistence.Contexts;
using ArtTableWeb.Persistence.Repositories;
using ArtTableWeb.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceService(this IServiceCollection services) 
        {

            //hangi veritabanıyla çalışacaksak onun kütüphanesini yüklüyoruz.
            services.AddDbContext<ArtTableWebDbContext>(options => options.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton);
            //IOC Conteiner ' da ICustomerReadRepository istendiğinde, CustomerReadRepository dönder.

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ArtTableWebDbContext>();

            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();

            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();

            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();

            services.AddSingleton<IAboutReadRepository,AboutReadRepository>();
            services.AddSingleton<IAboutWriteRepository,AboutWriteRepository>();

            services.AddSingleton<IBasketReadRepository,BasketReadRepository>();
            services.AddSingleton<IBasketWriteRepository,BasketWriteRepository>();

            services.AddSingleton<IBasketItemWriteRepository,BasketItemWriteRepository>();
            services.AddSingleton<IBasketItemReadRepository,BasketItemReadRepository>();

            services.AddSingleton<ICategoryReadRepository,CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository,CategoryWriteRepository>();

            services.AddSingleton<IContactWriteRepository,ContactWriteRepository>();
            services.AddSingleton<IContactReadRepository,ContactReadRepository>();

            services.AddSingleton<IProductImageFileReadRepository,ProductImageFileReadRepository>();
            services.AddSingleton<IProductImageFileWriteRepository,ProductImageFileWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();



        }

    }
}
