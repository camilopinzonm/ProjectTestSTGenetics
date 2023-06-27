using AutoMapper;
using TestStGenentics.Api.Domain.Implametations;
using TestStGenentics.Api.Services.Implementations;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;
using TestStGenentics.Shared.ModelResponse;
using static System.FormattableString;
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
            List<AnimalResponse> ListAnimalResponses = await ResponseCreatedList(animal);
            return ListAnimalResponses;
        }



        public async Task<List<AnimalResponse>> GetAllAsyncByFilter(AnimalResponse animalResponse)
        {

            string query = "Select * from Animals";
            var value = 0;
            if (animalResponse != null)
            {
                query = query + " where ";
                if (animalResponse.Name != null)
                {
                    query = query + " Name = '" + animalResponse.Name + "'";
                    value = 1;
                }
                if (animalResponse.BreedId != null && animalResponse.BreedId > 0)
                {
                    if (value==1)
                    {
                        query = query + " and ";
                    }
                    value = 1;
                    query = query + " BreedId = " + animalResponse.BreedId;
                    
                }
                if (animalResponse.BirthDate != null && animalResponse.BirthDate != Convert.ToDateTime("1/1/0001 0:00:00"))
                {
                    if (value == 1)
                    {
                        query = query + " and ";
                    }
                    query = query + " BirthDate = '" + animalResponse.BirthDate + "'"; 
                    value = 1;
                }
                if (animalResponse.SexId != null && animalResponse.SexId > 0)
                {
                    if (value == 1)
                    {
                        query = query + " and ";
                    }
                    query = query + " SexId = " + animalResponse.SexId;
                    value = 1;
                }
                if (animalResponse.Price != null )
                {
                    if (value == 1)
                    {
                        query = query + " and ";
                    }
                    query = query + " Price = " + animalResponse.Price;
                    value = 1;
                }
                if (animalResponse.StatusRowId != null && animalResponse.StatusRowId > 0)
                {
                    if (value == 1)
                    {
                        query = query + " and ";
                    }
                    query = query + " StatusRowId = " + animalResponse.StatusRowId;
                    value = 1;
                }
            }
            



            var animal = await _animalDbService.GetAllAsyncByFilter(query);
            List<AnimalResponse> ListAnimalResponses = await ResponseCreatedList(animal);
            return ListAnimalResponses;
        }

        private async Task<List<AnimalResponse>> ResponseCreatedList(List<Animal> animal)
        {
            List<AnimalResponse> ListAnimalResponses = new List<AnimalResponse>();


            foreach (var item in animal)
            {
                AnimalResponse a = new AnimalResponse();
                a.AnimalId = item.AnimalId;
                a.Name = item.Name;
                a.BreedId = item.BreedId;
                a.BirthDate = item.BirthDate;
                a.SexId = item.SexId;
                a.Price = item.Price;
                a.StatusRowId = item.StatusRowId;
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
