using ArtTableWeb.Application.Exceptions;
using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Services;
using ArtTableWeb.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Rules.User
{
    public class UserBusinessRules
    {
        readonly UserManager<AppUser> _userManager;

        public UserBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            AppUser result = await _userManager.FindByEmailAsync(email);
            if (result != null) throw new BusinessException("Mail adresiyle önceden kayıt olunmuş.");
        }
        public async Task UserShouldExistWhenRequested(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new BusinessException("Kullanıcı mevcut değil.");
        }
    }
}
