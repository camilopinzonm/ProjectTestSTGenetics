using AutoMapper;
using TestStGenentics.Shared.Entities;
using TestStGenentics.Shared.ModelResponse;

namespace TestStGenentics.Api.Profiles
{
    public class AnimalProfile:Profile
    {
        public AnimalProfile()
        {
            CreateMap<AnimalResponse, Animal>();
            CreateMap<Animal, AnimalResponse>();
        }
    }
}
