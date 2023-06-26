using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Interfaces
{
    public interface IBreedDbService
    {
        Task<Breed> GetAsync(int Id);
    }
}
