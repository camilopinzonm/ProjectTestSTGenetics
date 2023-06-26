using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Interfaces
{
    public interface IStatusRowService
    {
        Task<StatusRow> GetAsync(int Id);
    }
}
