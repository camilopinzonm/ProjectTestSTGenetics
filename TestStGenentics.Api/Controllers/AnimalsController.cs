using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Domain.Implametations;
using TestStGenentics.Shared.Entities;
using TestStGenentics.Shared.ModelResponse;

namespace TestStGenentics.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {

        private DataContext _context { get; }
        public IAnimalDomain _animalDomain { get; }

        public AnimalsController(DataContext context,IAnimalDomain animalDomain)
        {
            _context = context;
            _animalDomain = animalDomain;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var list = await _animalDomain.GetAll();
            return Ok(list);
        }

        [HttpPost("PostGetAll")]
        public async Task<ActionResult> PostGetAllAsync(AnimalResponse animalResponse)
        {

            var lista = await _animalDomain.GetAllAsyncByFilter(animalResponse);


            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(AnimalResponse animalResponse)
        {
            animalResponse = await _animalDomain.PostAsync(animalResponse);
            return Ok(animalResponse);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(AnimalResponse animal)
        {
            try
            {
                var a = await _animalDomain.PutAsync(animal);
                return Ok(a);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("There is already an animal with the same name.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _context.Animals.FirstOrDefaultAsync(x => x.AnimalId == id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Remove(data);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
