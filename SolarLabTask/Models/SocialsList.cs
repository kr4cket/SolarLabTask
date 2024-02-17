namespace SolarLabTask.Models
{
    public class SocialsList
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public int PersonId { get; set; }
        public int SocialsId { get; set;}

        public virtual required Socials Socials { get; set; }
        public virtual required Person Person { get; set; }

    }
}
