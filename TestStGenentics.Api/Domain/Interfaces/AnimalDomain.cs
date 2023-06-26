using AutoMapper;
using TestStGenentics.Api.Domain.Implametations;
using TestStGenentics.Api.Services.Implementations;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;
using TestStGenentics.Shared.ModelResponse;

namespace TestStGenentics.Api.Domain.Interfaces
{
    public class AnimalDomain : IAnimalDomain
    {
        public IAnimalDbService _animalDbService;
        private readonly IStatusRowService _statusRowDbService;
        private readonly ISexDbService _sexDbService;
        private readonly IBreedDbService _breedDbService;
        private readonly IMapper _mapper;
        public AnimalDomain(IMapper mapper, IAnimalDbService animalDbService, IStatusRowService statusRowDbService, ISexDbService sexDbService, IBreedDbService breedDbService)
        {
            _animalDbService = animalDbService;
            _statusRowDbService = statusRowDbService;
            _sexDbService = sexDbService;
            _breedDbService = breedDbService;
            _mapper=mapper;
        }

        public AnimalDbService AnimalDbService { get; }

        public async Task<List<AnimalResponse>> GetAll()
        {
            var animal = await _animalDbService.GetAllAsync();
            List<AnimalResponse> ListAnimalResponses = new List<AnimalResponse>();
            

            foreach (var item in animal)
            {
                AnimalResponse a = new AnimalResponse();
                a.AnimalId = item.AnimalId;
                a.Name= item.Name;
                a.BreedId = item.BreedId;
                a.BirthDate= item.BirthDate;
                a.SexId = item.SexId;
                a.Price= item.Price;
                a.StatusRowId= item.StatusRowId;
                a.StatusRowName = await GetStatus(item.StatusRowId);
                a.SexName = await GetSex(item.SexId);
                a.BreedName = await GetBreed(item.BreedId);
                ListAnimalResponses.Add(a);
                
            }
            return ListAnimalResponses;
        }

        private async Task<string> GetStatus(int Id)
        {
            var a = await _statusRowDbService.GetAsync(Id);
            return (a.Name);

        }

        private async Task<string> GetSex(int Id)
        {
            var a = await _sexDbService.GetAsync(Id);
            return (a.Name);

        }

        private async Task<string> GetBreed(int Id)
        {
            var a = await _breedDbService.GetAsync(Id);
            return (a.Name);

        }

        public async Task<AnimalResponse> PostAsync(AnimalResponse AnimalResponse)
        {

            var a = _mapper.Map<Animal>(AnimalResponse);
            var response = await _animalDbService.PostAsync(a);

            var AnimalResponse2 = _mapper.Map<AnimalResponse>(response);
            return AnimalResponse2;


            return AnimalResponse;

        }

        public async Task<AnimalResponse> PutAsync(AnimalResponse AnimalResponse)
        {

            var a = _mapper.Map<Animal>(AnimalResponse);
            var response = await _animalDbService.PutAsync(a);

            var AnimalResponse2 = _mapper.Map<AnimalResponse>(response);
            return AnimalResponse2;

        }
    }
}
