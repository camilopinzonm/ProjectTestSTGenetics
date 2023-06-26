using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Services.Interfaces
{
    public interface IAnimalDbService
    {
        Task<List<Animal>> GetAllAsync();
        Task<Animal> Get(int id);
        Task DeleteAsync(Animal animal);
        Task<Animal> PutAsync(Animal animal);
        Task<Animal> PostAsync(Animal animal);


    }
}
