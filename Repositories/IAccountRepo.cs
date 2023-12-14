using Microsoft.AspNetCore.Identity;
using Onlineshopping11.Models;
using OnlineShopping11.Models;
using System.Threading.Tasks;

namespace Onlineshopping11.Repositories
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(Login login);
    }
}