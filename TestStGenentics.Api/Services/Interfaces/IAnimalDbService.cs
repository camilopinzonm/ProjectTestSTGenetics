using TestStGenentics.Shared.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestStGenentics.Api.Services.Interfaces
{
    public interface IAnimalDbService
    {
        Task<List<Animal>> GetAllAsync();
        Task<Animal> Get(int id);
        Task<List<Animal>> GetAllAsyncByFilter(string query);
        Task DeleteAsync(Animal animal);
        Task<Animal> PutAsync(Animal animal);
        Task<Animal> PostAsync(Animal animal);


    }
}
