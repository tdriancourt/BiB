using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Bib.Api.Controllers
{
    [Route("api/media")]
    public class MediumController : Controller
    {
        private IMediumService _mediumService;

        public MediumController(IMediumService mediumService)
        {
            Contract.Requires(mediumService != null);
            _mediumService = mediumService;
        }

        [HttpGet("{id:int?}")]
        [ProducesResponseType(type: typeof(MediumViewModel), statusCode: 200)]
        public async Task<ActionResult> Mediums(int? id)
        {
            try
            {
                if(id.HasValue)
                    return Ok(await _mediumService.GetAsync(id.Value));
                else
                    return Ok(await _mediumService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());                
            }
        }
    }
}