using System.ComponentModel;

namespace SolarLabTask.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public int ImageId { get; set; }

        public required int CategoryId { get; set; }
        public required int UserId { get; set; }
        public required DateOnly DateOfBirth { get; set; }


        public virtual PersonImage? Image { get; set; }
        public virtual required PersonCategory PersonCategory { get; set; }
        public virtual required User User { get; set; }
    }
}
