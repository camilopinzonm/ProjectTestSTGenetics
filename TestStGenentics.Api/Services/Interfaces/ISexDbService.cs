using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Interfaces
{
    public interface ISexDbService
    {
        Task<Sex> GetAsync(int id);
    }
}
