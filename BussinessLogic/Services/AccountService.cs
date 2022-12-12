using AutoMapper;
using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Data.Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly WebForumDbContext context;

        public AccountService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, WebForumDbContext context)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task RegisterAsync(UserDto user)
        {
            var dbUser = mapper.Map<User>(user);
            var result = await userManager.CreateAsync(dbUser, user.Password);
            if (!result.Succeeded)
                throw new Exception("operation result is unsucceed");
        }

        public async Task<UserDto> LoginAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null || !await userManager.CheckPasswordAsync(user, password))
                throw new Exception("invalid email or password");

            await signInManager.SignInAsync(user, true);

            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await context.Users.FindAsync(id);

            return mapper.Map<UserDto>(user);
        }
    }
}
