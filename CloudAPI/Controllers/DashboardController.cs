using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudAPI.ApplicationCore.Interfaces;
using CloudAPI.ApplicationCore.Services;
using CloudAPI.Data;
using CloudAPI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace CloudAPI.Controllers
{
      [Authorize(Policy = "ApiUser")]
      [Route("api/[controller]/[action]")]
      public class DashboardController : Controller
      {
            private readonly ClaimsPrincipal _caller;
            private readonly ApplicationDbContext _appDbContext;
            private readonly ICustomerService _customerService;

            public DashboardController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor, ICustomerService customerService)
            {
                _caller = httpContextAccessor.HttpContext.User;
                _appDbContext = appDbContext;
                _customerService = customerService;
            }

            // GET api/dashboard/home
            [HttpGet]
            public async Task<IActionResult> Home()
            {
                //var a = _customerService.GetRecipeAsync(1).Result;

                //var userId = _caller.Claims.Single(c => c.Type == "id");
                //var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
                return new OkObjectResult("a");
                  //return new OkObjectResult(new
                  //{
                  //  Message = "This is secure API and user data!",
                  //  customer.Identity.FirstName,
                  //  customer.Identity.LastName,
                  //  customer.Identity.PictureUrl,
                  //  customer.Identity.FacebookId,
                  //  customer.Location,
                  //  customer.Locale,
                  //  customer.Gender
                  //});
            }
      }
}
