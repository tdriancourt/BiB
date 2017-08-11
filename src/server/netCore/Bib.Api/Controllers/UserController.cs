using Bib.Domain.Model;
using Bib.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bib.Services.ViewModels;

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
                if (id.HasValue)
                    return Ok(await _userService.GetAsync(id.Value));
                else
                    return Ok(await _userService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        //[ProducesResponseType()]
        #pragma warning disable CS1998
        public async Task<ActionResult> CreateUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(new { Status = true, User = user });
        }
    }
}