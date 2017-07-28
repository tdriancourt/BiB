using Bib.Domain.Model;
using Bib.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Bib.Api
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            Contract.Requires(userService != null);

            _userService = userService;
        }
        
        [HttpGet("{id:int?}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> Users(int? id)
        {
            try
            {
                var users =  await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());                
            }
        }

        [HttpPost]
        //[ProducesResponseType()]
        public async Task<ActionResult> CreateUser([FromBody]User user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(new { Status = true, User = user });
        }
    }
}