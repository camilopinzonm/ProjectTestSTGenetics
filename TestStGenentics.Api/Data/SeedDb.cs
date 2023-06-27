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
            await CheckStatusAsync();
            await CheckBreedsAsync();
            await CheckSexAsync();
            await CheckAnimalsAsync();

        }


        private async Task CheckSexAsync()
        {
            if (!_context.Sexs.Any())
            {
                _context.Sexs.Add(new Sex { Name = "Male" });
                _context.Sexs.Add(new Sex { Name = "Female" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBreedsAsync()
        {
            if (!_context.Breeds.Any())
            {
                _context.Breeds.Add(new Breed { Name = "Shorthorn" });
                _context.Breeds.Add(new Breed { Name = "Hereford" });
                _context.Breeds.Add(new Breed { Name = "Aberdeen Angus" });
                _context.Breeds.Add(new Breed { Name = "Charolaise" });
                _context.Breeds.Add(new Breed { Name = "Limousin" });
                _context.Breeds.Add(new Breed { Name = "Pardo" });
                _context.Breeds.Add(new Breed { Name = "Fleckvieh" });
                _context.Breeds.Add(new Breed { Name = "Brangus" });
                _context.Breeds.Add(new Breed { Name = "Jersey" });
                _context.Breeds.Add(new Breed { Name = "Holando" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStatusAsync()
        {
            if (!_context.StatusRows.Any())
            {
                _context.StatusRows.Add(new StatusRow { Name = "Inactive" });
                _context.StatusRows.Add(new StatusRow { Name = "Active" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAnimalsAsync()
        {
            if (!_context.Animals.Any())
            {
                _context.Animals.Add(new Animal { Name = "Ramon", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId=1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Jose", BreedId = 2, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Clarita", BreedId = 3, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Morro", BreedId = 4, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Santo", BreedId = 4, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Pleta", BreedId = 6, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre1", BreedId = 5, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre2", BreedId = 8, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre3", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre41", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre5", BreedId = 9, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre55", BreedId = 4, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre6", BreedId = 3, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre7", BreedId = 6, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre8", BreedId = 7, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre9", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre77", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre11", BreedId = 1, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre34", BreedId = 2, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 2, Price = 10, StatusRowId = 2 });
                _context.Animals.Add(new Animal { Name = "Sin Nombre14", BreedId = 10, BirthDate = Convert.ToDateTime("01/01/1983"), SexId = 1, Price = 10, StatusRowId = 2 });

                await _context.SaveChangesAsync();
            }
        }

    }
}
