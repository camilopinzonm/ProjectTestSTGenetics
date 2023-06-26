using TestStGenentics.Shared.ModelResponse;

namespace TestStGenentics.Api.Domain.Implametations
{
    public interface IAnimalDomain
    {
        Task<List<AnimalResponse>> GetAll();
        Task<AnimalResponse> PostAsync(AnimalResponse AnimalResponse);
        Task<AnimalResponse> PutAsync(AnimalResponse AnimalResponse);
    }
}
