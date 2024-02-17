namespace SolarLabTask.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public List<SocialsList>? SocialList { get; set; }

    }
}
