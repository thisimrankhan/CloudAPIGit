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
      public class RecipieController : Controller
      {
            private readonly ClaimsPrincipal _caller;
            private readonly ApplicationDbContext _appDbContext;
            private readonly IRecipieService _recipieService;

            public RecipieController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IRecipieService recipieService)
            {
                _caller = httpContextAccessor.HttpContext.User;
                _appDbContext = appDbContext;
                _recipieService = recipieService;
            }

            // GET api/Recipie/GetRecipie
            [HttpGet]
            public IActionResult GetRecipie(int Id)
            {
                var recipie = _recipieService.GetRecipieById(Id).Result;
                return new OkObjectResult(recipie);
            }
            // GET api/Recipie/
            [HttpGet]
            public IActionResult GetRecipies()
            {
                var recipies = _recipieService.GetRecipies().Result;
                return new OkObjectResult(recipies);
            }
    }
}
