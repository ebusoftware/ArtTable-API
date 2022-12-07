using ArtTableWeb.Application.Abstractions.Storage;
using ArtTableWeb.Application.Abstractions;
using ArtTableWeb.Infrastructure.Services.Storage.Azure;
using ArtTableWeb.Infrastructure.Services.Storage.Local;
using ArtTableWeb.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;
using ArtTableWeb.Infrastructure.Enums;

namespace ArtTableWeb.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local: //Storage tipi eğer lokal ise IOC de IStorage'a karşılık LocalStorage'ı ver.
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();//Storage Belirtilmemişse, default olarak local yap.
                    break;
            }
        }
    }
}
