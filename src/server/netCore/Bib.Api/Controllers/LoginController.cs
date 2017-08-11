using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            Contract.Requires(userService != null);

            _userService = userService;
        }

        [Route("api/login")]
        [HttpPost]
        public async Task<ActionResult> Logon([FromBody]LoginViewModel loginViewModel)
        {
            try
            {
                var loginResult = false;
                if(await _userService.Authenticate(loginViewModel))
                {
                    loginResult = true;
                }

                return Ok(loginResult);
            }
            catch (System.Exception ex)
            {
                return BadRequest(false);
            }
            
        }
    }
}