using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sipay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class getPosController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Installments(Installment ınstallment)
        {
            return BadRequest();
        }
    }
}
