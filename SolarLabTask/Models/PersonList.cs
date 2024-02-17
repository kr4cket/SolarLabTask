namespace SolarLabTask.Models
{
    public class PersonList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public int PersonCategoryId {  get; set; }


        public virtual required PersonCategory PersonCategory { get; set; }
        public virtual required Person Person { get; set; }
        public virtual required User User { get; set; }
    }
}
