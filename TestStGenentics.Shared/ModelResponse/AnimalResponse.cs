using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStGenentics.Shared.ModelResponse
{
    public class AnimalResponse
    {
        public int AnimalId { get; set; }

        public string? Name { get; set; }


        public int BreedId { get; set; }

        public DateTime BirthDate { get; set; }

        public int SexId { get; set; }

        public decimal Price { get; set; }

        public int StatusRowId { get; set; }

        public string? BreedName { get; set; }
        public string? SexName { get; set; }
        public string? StatusRowName { get; set; }
    }
}
