using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {

        private DataContext _context { get; }
        public AnimalsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _context.Animals.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Animal animal)
        {
            _context.Add(animal);
            await _context.SaveChangesAsync();
            return Ok(animal);
        }
    }
}
