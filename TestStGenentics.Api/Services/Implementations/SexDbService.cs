using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Implementations
{
    public class SexDbService:ISexDbService
    {
        private readonly DataContext _context;

        public SexDbService(DataContext context)
        {
            _context = context;
        }
        public async Task<Sex> GetAsync(int id)
        {
            var data = await _context.Sexs
                    .FirstOrDefaultAsync(x => x.Id == id);

            return data;

        }
    }
}
