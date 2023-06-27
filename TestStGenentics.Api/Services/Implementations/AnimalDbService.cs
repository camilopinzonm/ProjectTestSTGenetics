using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Services.Interfaces;
using TestStGenentics.Shared.Entities;
using static System.FormattableString;

namespace TestStGenentics.Api.Services.Implementations
{


    public class AnimalDbService:IAnimalDbService
    {
        public string X { get; set; } = "This is X";
        public string Y { get; set; } = "This is Y";
        public string Z { get; set; } = "This is Z";

        private DataContext _context { get; }
        public AnimalDbService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Animal>> GetAllAsync()
        {
            var list = await _context.Animals.ToListAsync();
            return list; 
        }

        public async Task<List<Animal>> GetAllAsyncByFilter(String querye)
        {
            
            var list =  _context.Animals.FromSqlRaw(querye).ToList();
            return list;
        }

        public async Task<Animal> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Animal animal)
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> PutAsync(Animal animal)
        {
            try
            {
                _context.Update(animal);
                await _context.SaveChangesAsync();
                return animal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Animal> PostAsync(Animal animal)
        {
            try
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return animal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
