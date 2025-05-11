using System;
using System.Security.Authentication;
using System.Security.Claims;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager,
         ClaimsPrincipal user)
    {
        var usertoReturn = await userManager.Users.FirstOrDefaultAsync(x => 
            x.Email == user.GetEmail());

        if (usertoReturn == null) throw new AuthenticationException("User not found");

        return usertoReturn;
    }

        public static async Task<AppUser> GetUserByEmailWithAddress(this UserManager<AppUser> userManager,
             ClaimsPrincipal user)
    {
        var usertoReturn = await userManager.Users
        .Include(x => x.Address)
        .FirstOrDefaultAsync(x => x.Email == user.GetEmail());

        if (usertoReturn == null) throw new AuthenticationException("User not found");

        return usertoReturn;
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email) 
            ?? throw new AuthenticationException("Email claim not found");

        return email;
    }
}
