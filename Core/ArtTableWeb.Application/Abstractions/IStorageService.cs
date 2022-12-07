using ArtTableWeb.Application.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Abstractions
{
    public interface IStorageService:IStorage
    {
        public string StorageName { get; }
    }
}
