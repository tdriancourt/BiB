using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics.Contracts;
using System.IO;

namespace Bib.Api.Controllers
{
    public class TranslationController : Controller
    {
        private IFileProvider _fileProvider;
        
        public TranslationController(IAssetFileProvider fileProvider)
        {
            Contract.Requires(fileProvider != null);
            _fileProvider = fileProvider;
        }
        
        [Route("api/translations/{languageCode}")]
        [Produces("application/json")]
        public ActionResult GetTranslations(string languageCode)
        {
            var fileInfo = _fileProvider.GetFileInfo($"/{languageCode}.json");
            return File(fileInfo.CreateReadStream(), "application/json");
        }
    }
}