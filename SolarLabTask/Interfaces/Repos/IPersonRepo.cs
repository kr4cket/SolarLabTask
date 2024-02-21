using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IPersonRepo : IAppRepo<Person, Person>
    {
        public IEnumerable<Person> GetListByUserId(int Id);
        public PersonImage GetImageById(int Id);
    }
}
