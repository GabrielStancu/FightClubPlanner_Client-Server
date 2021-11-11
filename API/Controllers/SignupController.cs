using Core.Helpers;
using Infrastructure.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupCheckService _signupCheckService;

        public SignupController(ISignupCheckService signupCheckService)
        {
            _signupCheckService = signupCheckService;
        }

        [HttpPost]
        public async Task<ActionResult<SignupResult>> SignUp(SignupUserDTO signupUserDTO)
        {
            var signupResult = await _signupCheckService.CheckCredentialsAsync(signupUserDTO);
            return Ok(signupResult);
        }
    }
}
