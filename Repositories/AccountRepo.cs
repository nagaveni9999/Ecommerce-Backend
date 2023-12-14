using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Onlineshopping11.Models;
using static Onlineshopping11.Repositories.AccountRepo;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using OnlineShopping11.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Onlineshopping11.Repositories
{

    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountRepo(UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,login.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUsers()
            {
                CustomerName = signUpModel.FirstName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await _userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}
