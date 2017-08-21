using Bib.Domain.Model;
using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Bib.Api
{
    [Route("api/acls")]
    public class AclController : Controller
    {
        private IAclService _aclService;
        public AclController(IAclService aclService)
        {
            Contract.Requires(aclService != null);
            _aclService = aclService;
        }

        [HttpGet("{id:int?}")]
        [ProducesResponseType(type: typeof(AclViewModel), statusCode: 200)]
        public async Task<ActionResult> Acls(int? id)
        {
            try
            {
                if(id.HasValue)
                    return Ok(await _aclService.GetAsync(id.Value));
                else
                    return Ok(await _aclService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        //[ProducesResponseType()]
        #pragma warning disable CS1998
        public async Task<ActionResult> CreateAcl([FromBody]Acl acl)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(new { Status = true, Acl = acl });
        }
    }
}