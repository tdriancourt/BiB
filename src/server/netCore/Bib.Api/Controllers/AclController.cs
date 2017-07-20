using Bib.Domain.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api
{
    [Route("api/acls")]
    public class AclController : Controller
    {
        [HttpGet("{id:int?}")]
        //[ProducesResponseType()]
        public async Task<ActionResult> Acls(int? id)
        {
            return Ok();
        }

        [HttpPost]
        //[ProducesResponseType()]
        public async Task<ActionResult> CreateAcl([FromBody]Acl acl)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(new { Status = true, Acl = acl });
        }
    }
}