using Microsoft.AspNetCore.Mvc;
using Onlineshopping11.Models;
using OnlineShopping11.Models;
using Onlineshopping11.Repositories;
using System.Threading.Tasks;

namespace Onlineshopping11.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase       
        {

            private readonly IAccountRepo repository;
            public AccountController(IAccountRepo repo)
            {
                repository = repo;
            }
            [HttpPost("signup")]
            public async Task<IActionResult> SignUp(SignUpModel signupModel)
            {
                var result = await repository.SignUpAsync(signupModel);
                if (result.Succeeded)
                {
                    return Ok(result);

                }
                return Unauthorized();
            }

            [HttpPost("Login")]
            public async Task<IActionResult> SignIn([FromBody] Login login)
            {
                var result = await repository.LoginAsync(login);
                if (string.IsNullOrEmpty(result))
                {
                    return Unauthorized();
                }
                return Ok(result);
            }
        }
}


