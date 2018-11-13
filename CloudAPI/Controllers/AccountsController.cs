

using System.Threading.Tasks;
using CloudAPI.Data;
using CloudAPI.Helpers;
using CloudAPI.Models.Entities;
using CloudAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Linq;
using System.Net.Http;

namespace CloudAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext, IEmailSender emailSender)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _emailSender = emailSender;
        }

        // POST api/accounts/sendemail
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody]ResendEmailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.UserId == null)
                {
                    return BadRequest(ModelState);
                }
                var userIdentity = _userManager.Users.Where(c => c.Id == model.UserId.ToString()).FirstOrDefault();
                if (userIdentity != null)
                {
                    await _emailSender.SendEmailAsync(userIdentity.Email, "Account Verification",
                            $"Your email verification code is <b>{userIdentity.PhoneNumber}</b>.");

                    return new OkObjectResult(userIdentity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Random rnd = new Random();
            string numericCode = rnd.Next(1, 99999).ToString("D5");

            var userIdentity = _mapper.Map<AppUser>(model);
            userIdentity.FirstName = model.FullName;
            userIdentity.PhoneNumber = numericCode.ToString();
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (result.Succeeded)
            {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                await _emailSender.SendEmailAsync(model.Email, "Account Verification",
                    $"Your email verification code is <b>{numericCode}</b>.");
            }

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = "" });
            await _appDbContext.SaveChangesAsync();

            var user = _userManager.Users.Where(u => u.Id == userIdentity.Id).FirstOrDefault();
            return new OkObjectResult(user);
        }
    }
}
