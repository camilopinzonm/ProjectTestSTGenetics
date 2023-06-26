using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Implementations
{
    public class StatusRowDbService : IStatusRowService
    {
        private readonly DataContext _context;

        public StatusRowDbService(DataContext context)
        {
            _context = context;
        }
        public async Task<StatusRow> GetAsync(int Id)
        {
            var statusRow = await _context.StatusRows
                    .FirstOrDefaultAsync(x => x.Id == Id);

            return statusRow;

        }
    }
}
