using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api.Controllers
{
    [Route("api/usergroups")]
    public class UserGroupController : Controller
    {
        private IUserGroupService _userGroupService;

        public UserGroupController(IUserGroupService userGroupService)
        {
            Contract.Requires(userGroupService != null);
            _userGroupService = userGroupService;
        }

        [HttpGet("{id:int?}")]
        [ProducesResponseType(type: typeof(UserGroupViewModel), statusCode: 200)]
        public async Task<ActionResult> UserGroups(int? id)
        {
            try
            {
                if(id.HasValue)
                    return Ok(await _userGroupService.GetAsync(id.Value));
                else
                    return Ok(await _userGroupService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}