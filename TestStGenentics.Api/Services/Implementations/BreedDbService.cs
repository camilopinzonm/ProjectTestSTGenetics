using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Implementations
{
    public class BreedDbService: IBreedDbService
    {
        private readonly DataContext _context;

        public BreedDbService(DataContext context)
        {
            _context = context;
        }
        public async Task<Breed> GetAsync(int id)
        {
            var data = await _context.Breeds.FirstOrDefaultAsync(x => x.Id == id);
            return data;

        }
    }
}
