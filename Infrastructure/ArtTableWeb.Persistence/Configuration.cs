﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get 
            {
                //microsoft.extensions.configuration kütüphanesini ekle
                ConfigurationManager configurationManager = new();
                //microsoft.extensions.configuration.json ekle
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ArtTableWeb.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("MsSql");
            }
        }
    }
}
