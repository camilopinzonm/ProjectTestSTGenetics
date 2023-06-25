using TestStGenentics.Api.Data;

namespace TestStGenentics.Api.Domain.Implementations
{
    public class DataBaseService
    {
        private DataContext _context { get; }
        public DataBaseService(DataContext context)
        {
            _context = context;
        }

    }
}
