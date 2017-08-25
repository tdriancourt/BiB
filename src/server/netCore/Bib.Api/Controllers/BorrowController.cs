using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Bib.Services;
using Bib.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bib.Api.Controllers
{
    [Route("api/borrows")]
    public class BorrowController : Controller
    {
        private IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            Contract.Requires(borrowService != null);
            _borrowService = borrowService;
        } 

        [HttpGet("{id:int?}")]
        [ProducesResponseType(type: typeof(BorrowViewModel), statusCode: 200)]
        public async Task<ActionResult> Borrows(int? id)  
        {
            try
            {
                if(id.HasValue)
                    return Ok(await _borrowService.GetAsync(id.Value));
                else
                    return Ok(await _borrowService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}