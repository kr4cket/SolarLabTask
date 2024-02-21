using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Services
{
    public interface IPersonService
    {
        public User GetUser(int Id);
        public IEnumerable<PersonCategory> GetCategoryList();
        public void CreateUser(Person person, int UserId, IFormFile? File);
        public void UpdateUser(Person person, int UserId, IFormFile? File);

    }
}
