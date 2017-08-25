using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api.Controllers
{
    [Route("api/mediatypes")]
    public class MediaTypeController : Controller
    {
        private IMediaTypeService _mediaTypeService;

        public MediaTypeController(IMediaTypeService mediaTypeService)
        {
            Contract.Requires(mediaTypeService != null);
            _mediaTypeService = mediaTypeService;
        }

        [HttpGet("{id:int?}")]
        [ProducesResponseType(type: typeof(MediaTypeViewModel), statusCode: 200)]
        public async Task<ActionResult> MediaTypes(int? id)
        {
            try
            {
                if(id.HasValue)
                    return Ok(await _mediaTypeService.GetAsync(id.Value));
                else
                    return Ok(await _mediaTypeService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}