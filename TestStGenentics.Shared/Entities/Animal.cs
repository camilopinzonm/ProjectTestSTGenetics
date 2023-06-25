using System.ComponentModel.DataAnnotations;

namespace TestStGenentics.Shared.Entities
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }


        [MaxLength(100)]
        public string? Name { get; set; }


        public int BreedId { get; set; }

        public DateTime BirthDate { get; set; }



        public int SexId { get; set; }


        public decimal Price { get; set; }

        public int StatusRowId { get; set; }

        public Breed? Breed { get; set; }
        public Sex? Sex { get; set; }
        public StatusRow? StatusRow  { get; set; }
    }
}
