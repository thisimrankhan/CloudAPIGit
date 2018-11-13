

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudAPI.Auth;
using CloudAPI.Helpers;
using CloudAPI.Models;
using CloudAPI.Models.Entities;
using CloudAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
 

namespace CloudAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyCode([FromBody]VerifyCodeViewModel verifyCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.Users.Where(u=> u.Id == verifyCode.Id).FirstOrDefault();

            IdentityResult result = null;
            System.Exception ex;
            if(user.PhoneNumber == verifyCode.VerificationCode)
            {
                user.EmailConfirmed = true;
                result = await _userManager.UpdateAsync(user);
            }
            else
            {
                ex = new System.Exception("Verification Failed");
                throw ex;
            }
            return new OkObjectResult(result);
        }


        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username/password or verification failed.", ModelState));
            }
            
          var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
          return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);
            
            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);
            
            //Email confirmation
            if (!userToVerify.EmailConfirmed) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
