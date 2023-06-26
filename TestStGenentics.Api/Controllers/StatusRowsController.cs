using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;

namespace TestStGenentics.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class StatusRowsController : ControllerBase
    {
        private DataContext _context { get; }
        public StatusRowsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {

            return Ok(await _context.StatusRows.ToListAsync());
        }
    }
}
