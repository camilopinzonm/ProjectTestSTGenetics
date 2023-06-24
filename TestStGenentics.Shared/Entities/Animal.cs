using System.ComponentModel.DataAnnotations;

namespace TestStGenentics.Shared.Entities
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }


        [MaxLength(100)]
        public string? Name { get; set; }


        [MaxLength(100)]
        public string? Breed { get; set; }

        public DateTime BirthDate { get; set; }


        [MaxLength(25)]
        public string? Sex { get; set; }


        public decimal Price { get; set; }


        [MaxLength(25)]
        public string? Status { get; set; }
    }
}
