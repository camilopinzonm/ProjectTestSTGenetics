using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Domain.Interfaces
{
    public interface IDataBaseService
    {
        Task<List<Animal>> GetAll();
        Task<Animal> Get(int id);
        Task Delete(int id);


    }
}
