using TestStGenentics.Shared.Entities;

namespace TestStGenentics.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;


        public SeedDb(DataContext context)
        {
            _context = context;

        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await CheckStatusAsync();
            //await CheckBreedsAsync();
            //await CheckSexAsync();
            await CheckAnimalsAsync();

        }


        //private Task CheckSexAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //private Task CheckBreedsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //private Task CheckStatusAsync()
        //{
        //    throw new NotImplementedException();
        //}

        private async Task CheckAnimalsAsync()
        {
            if (!_context.Animals.Any())
            {
                _context.Animals.Add(new Animal { Name = "Clarita", Breed = "1", BirthDate = Convert.ToDateTime("01/01/1983"), Sex = "1", Price = 0, Status = "1" });
                await _context.SaveChangesAsync();
            }
        }

    }
}
