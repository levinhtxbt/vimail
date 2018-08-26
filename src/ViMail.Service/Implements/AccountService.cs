using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ViMail.Data.Entities;
using ViMail.Service.Interfaces;

namespace ViMail.Service.Implements
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var result = await _userManager.CreateAsync(new User()
            {
                UserName = username,
                Email = "levinhtxbt@gmail.com"
            }, password);

            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);


            return result.Succeeded;
        }
    }
}
