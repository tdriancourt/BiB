using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Bib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api.Controllers
{
    public class MediaController : Controller
    {
        private IMediaService _mediaRepository;
        public MediaController(IMediaService mediaRepository)
        {
            Contract.Requires(mediaRepository != null);
            _mediaRepository = mediaRepository;
        }

        public async Task<ActionResult> Media(int id)
        {
            return Ok();
        }
    }
}