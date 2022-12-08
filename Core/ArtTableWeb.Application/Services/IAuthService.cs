using ArtTableWeb.Application.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Services
{
    public interface IAuthService:IExternalAuthentication,IInternalAuthentication
    {

    }
}
