﻿using BlazorChat.Server.Data;
using BlazorChat.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineUsersController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public OnlineUsersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<UserDto> Get()
        {
            List<ApplicationUser> applicationUsers = applicationDbContext.Users.ToList();
            return applicationDbContext.Users
                .Where(user => user.IsOnline)
                .ToList()
                .Select(user => 
                {
                    ApplicationUser applicationUser = applicationUsers.Find(appUser => appUser.Id == user.Id);
                    return new UserDto
                    {
                        Id = user.Id.ToString(),
                        IDP = applicationDbContext.UserLogins.Where(userLogin => userLogin.UserId == user.Id.ToString()).First().LoginProvider,
                        Image = applicationUser.PictureUri,
                        Name = applicationUser.UserName
                    };
                });
        }
    }
}